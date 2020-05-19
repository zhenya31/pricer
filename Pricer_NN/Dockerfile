FROM python:3.7

RUN mkdir -p /flask-app/
WORKDIR /flask-app/

COPY . /flask-app/
# RUN pip install --no-cache-dir -r requirements.txt
RUN apt-get update; apt-get install tesseract-ocr -y
RUN pip install -r requirements.txt

EXPOSE 5050

CMD ["python", "app.py"]