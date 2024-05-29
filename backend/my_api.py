import requests
import sys

def send_image(image_path):
    url = "http://127.0.0.1:5000/detect"

    with open(image_path, 'rb') as image_file:
        files = {'image': (image_path, image_file, 'multipart/form-data')}
        response = requests.post(url, files=files)
        if response.status_code == 200:
            print(response.text)
        else:
            print('Failed to get a response, status code:', response.status_code)

if __name__ == '__main__':
    image_path = sys.argv[1]
    send_image(image_path)