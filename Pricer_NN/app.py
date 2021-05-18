import cv2
import os
import numpy as np
from flask import Flask
import price_ocr as ocr
import json
import base64
from flask import request, abort, jsonify
import price_detector as nn

# os.environ['KMP_DUPLICATE_LIB_OK']='True'
app = Flask(__name__)


def readb64(uri):
    # nparr = np.fromstring(base64.b64decode(uri), np.uint8)
    nparr = np.frombuffer(base64.b64decode(uri), np.uint8)

    img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
    return img


@app.route('/detector', methods=['POST', 'GET'])
def detector():
    try:
        if not request.json or 'image' not in request.json:
            abort(400)

        image = readb64(request.json['image'])
        response = dict()
        response['box'] = nn.get_box(nn.to_tensor(image))
        print(response['box'])
        response['texts'] = ocr.read_price(image, response['box'])
        print(response['texts'])
        response['error'] = None
        return jsonify(response)
    except Exception as ex:
        response = dict()
        response['box'] = None
        response['texts'] = None
        response['error'] = str(ex)
        return jsonify(response)


if __name__ == '__main__':
    app.run(host="flask", port="5050", debug=True)
