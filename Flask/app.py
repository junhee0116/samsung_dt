from flask import Flask, request, jsonify, render_template
import mysql.connector
from mysql.connector import Error

app = Flask(__name__)

# MySQL 데이터베이스 연결 설정
db_config = {
    'user' : 'root',
    'password' : '1234',
    'host' : '10.0.0.12',
    'database' : 'sensor_data',
    'port' : 3308
}

@app.route('/light_data', methods = ['POST'])
def receive_light_data():
    data = request.json
    light_level = data.get("light_level")
    voltage = data.get("voltage")

    if light_level is None or voltage is None:
        return jsonify({"error": "Invalid data"}), 400
    
    #MySQL 연결 및 데이터 저장
    try:
        conn = mysql.connector.connect(**db_config)
        if conn.is_connected():
            cursor = conn.cursor()

            # SQL INSERT 쿼리 작성
            insert_query = "INSERT INTO light_data (light_level, voltage) VALUES (%s, %s)"
            cursor.execute(insert_query, (light_level, voltage))

            # 변경 사항 저장
            conn.commit()

            return jsonify({"message" : "Data received and stored successfully"}), 201
        else:
            return jsonify({"error": "MySQL connection failed"}), 500

    except Error as e:
        print(f"Error: {e}")
        return jsonify({"error": str(e)}), 500
    
    finally:
        if cursor:
            cursor.close()
        if conn:
            conn.close()

@app.route('/dist_data', methods = ['POST'])
def receive_dist_data():
    data = request.json
    distance = data.get("distance")

    if distance is None:
        return jsonify({"error": "Invalid data"}), 400
    
    #MySQL 연결 및 데이터 저장
    try:
        conn = mysql.connector.connect(**db_config)
        if conn.is_connected():
            cursor = conn.cursor()

            # SQL INSERT 쿼리 작성
            insert_query = "INSERT INTO dist_data (distance) VALUES (%s)"
            cursor.execute(insert_query, (distance, ))

            # 변경 사항 저장
            conn.commit()

            return jsonify({"message" : "Data received and stored successfully"}), 201
        else:
            return jsonify({"error": "MySQL connection failed"}), 500

    except Error as e:
        print(f"Error: {e}")
        return jsonify({"error": str(e)}), 500
    
    finally:
        if cursor:
            cursor.close()
        if conn:
            conn.close()

@app.route('/')
def hello():
    #MySQL 연결 및 데이터 저장
    try:
        conn = mysql.connector.connect(**db_config)
        cursor = conn.cursor()

        # 최근 데이터 12개를 가져오는 쿼리
        select_light_query = "SELECT light_level FROM light_data ORDER BY timestamp DESC LIMIT 12"
        cursor.execute(select_light_query)
        light_result = cursor.fetchall()

        light_data = [row[0] for row in light_result]
        

        select_dist_query = "SELECT distance FROM dist_data ORDER BY timestamp DESC LIMIT 12"
        cursor.execute(select_dist_query)
        dist_result = cursor.fetchall()

        dist_data = [row[0] for row in dist_result]
    except Error as e:        
        print(f"Error: {e}")
        date = [] # 에러가 발생하면 빈 리스트로 설정

    finally:
        if cursor:
            cursor.close()
        if conn:
            conn.close()
    return render_template('index.html', data1 = light_data, data2 = dist_data)

if __name__ == '__main__':
    app.run('0.0.0.0', port = 5000, debug = True)