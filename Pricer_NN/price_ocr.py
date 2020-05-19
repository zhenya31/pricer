import pytesseract
from pytesseract import Output
import cv2
import random


def read_price(image, box):
    texts = set()
    for x in range(0, 24, 4):
        for y in range(2, 24, 4):
            padd_x = x + random.randint(0, 3)
            padd_y = y + random.randint(0, 3)
            img = image[box[1] - padd_y:box[3] + padd_y, box[0] - padd_x:box[2] + padd_x]
            img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
            text = pytesseract.image_to_string(img, config=r' -l eng+rus --psm 11')
            if text != '':
                texts.add(text)

    return list(texts)

