# RabbitMQ-With-Dot-Net-8.0

pre-req:
Docker 

// pull rabbitmq image with version 3 and along with management tag it is RabbitMQ Management Plugin, which provides a web-based UI for monitoring and managing RabbitMQ.

Command : This is rabbitmq image.

----->>> docker pull rabbitmq:3-management

start the container 

----->>>>> docker run -d --name my-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management


I took reference from here
https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/
