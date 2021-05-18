FROM python:3.7

RUN mkdir -p /flask-app/
WORKDIR /flask-app/

ADD ./requirements.txt .

RUN apt-get update && apt-get install -y python3-opencv
#RUN pip install opencv-python
RUN apt-get update; apt-get install tesseract-ocr -y
RUN pip install -r requirements.txt

ADD . .
# RUN pip install --no-cache-dir -r requirements.txt


CMD ["python", "-u", "app.py"]