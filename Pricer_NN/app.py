import cv2
import os
import numpy as np
from flask import Flask
import price_ocr as ocr
import json
import base64
from flask import request, abort, jsonify
import price_detector as nn

#os.environ['KMP_DUPLICATE_LIB_OK']='True'
app = Flask(__name__)

def readb64(uri):
   nparr = np.fromstring(base64.b64decode(uri), np.uint8)
   img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
   return img

@app.route('/', methods=['GET'])
def home():
    return "1";

@app.route('/detector', methods=['POST'])
def detector():
    try:
        if not request.json or not 'image' in request.json:
            abort(400)

        image = readb64(request.json['image'])
        response = {}
        response['box'] = nn.get_box(nn.to_tensor(image))
        response['texts'] = ocr.read_price(image, response['box'])
        response['error'] = None
        return jsonify(response)
    except Exception as ex:
        response = {}
        response['box'] = None
        response['texts'] = None
        response['error'] = str(ex)
        return jsonify(response)


if __name__ == '__main__':
    app.run(host="0.0.0.0", port="5050", debug=False)
