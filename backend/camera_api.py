from flask import Flask, Response, jsonify
import cv2

app = Flask(__name__)

# Initialize the camera
camera = cv2.VideoCapture(0)

@app.route('/api/camera/frame', methods=['GET'])
def get_frame():
    success, frame = camera.read()
    if not success:
        return jsonify({'error': 'Failed to capture image'}), 500

    ret, buffer = cv2.imencode('.jpg', frame)
    if not ret:
        return jsonify({'error': 'Failed to encode image'}), 500

    return Response(buffer.tobytes(), mimetype='image/jpeg')

@app.route('/api/camera/shutdown', methods=['GET'])
def shutdown():
    camera.release()
    return jsonify({'message': 'Camera released'}), 200

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
