# 베이스 이미지를 설정합니다.
FROM python:3.10

# bash alias를 설정합니다.
RUN echo "alias ll='ls -l'" >> ~/.bashrc

# 작업 디렉토리를 설정하고 애플리케이션 파일을 복사합니다.
WORKDIR /app
COPY . /app

# 필요한 Python 패키지를 설치합니다.
RUN pip install --no-cache-dir flask pymysql mysql-connector-python

# 환경 변수를 설정하여 Flask가 애플리케이션을 찾을 수 있도록 합니다.
ENV FLASK_APP=app

# Flask 애플리케이션을 실행합니다.
CMD ["flask", "run", "--host=0.0.0.0"]