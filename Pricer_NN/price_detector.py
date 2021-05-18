import torch
import numpy as np
import cv2
import torchvision

from torchvision.models.detection.faster_rcnn import FastRCNNPredictor

def init_model():
    # load a model pre-trained pre-trained on COCO
    model = torchvision.models.detection.fasterrcnn_resnet50_fpn(pretrained=False)

    # replace the classifier with a new one, that has
    # num_classes which is user-defined
    num_classes = 2  # 1 class (person) + background
    # get number of input features for the classifier
    in_features = model.roi_heads.box_predictor.cls_score.in_features
    # replace the pre-trained head with a new one
    model.roi_heads.box_predictor = FastRCNNPredictor(in_features, num_classes)

    model.load_state_dict(torch.load('model_25_04.pt', map_location=torch.device('cpu')))
    # model = torch.load("model_v1.pt", map_location=torch.device('cpu'))
    model.eval()
    return model

model = init_model()
print('Модель скачана')


def to_tensor(image):
    if image.shape[2] == 4:  # убираем альфа-канал
        image = image[:, :, :3]
    image = image.transpose((2, 0, 1))
    return torch.as_tensor([image / 255], dtype=torch.float32)


def get_box(tensor):
    outputs = model.forward(tensor)
    if len(outputs[0]['boxes']) == 0:
        return [0, 0, 0, 0]
    box = outputs[0]['boxes'][0]
    box = torch.as_tensor(torch.round(box), dtype=torch.int16)
    box = box.tolist()
    print(box)
    return box

