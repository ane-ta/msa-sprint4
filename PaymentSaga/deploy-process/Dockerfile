#якобы очень тяжелый
#FROM camunda/zeebe:8.5.22
#
#USER root
#
#RUN apt-get update && \
    #apt-get install -y curl netcat-openbsd && \
    #curl -L -o /usr/local/bin/zbctl https://github.com/camunda/zeebe/releases/download/8.5.22/zbctl && \
    #chmod +x /usr/local/bin/zbctl && \
    #apt-get remove -y curl && \
    #apt-get autoremove -y && \
    #apt-get clean
#
#ENTRYPOINT ["sh", "-c"]
#----------------------------------
# Используем максимально легкий образ
FROM alpine:3.18

# Добавляем аргумент сборки
ARG ZBCTL_VERSION

# Устанавливаем только необходимые зависимости для работы скрипта и zbctl
RUN apk add --no-cache curl netcat-openbsd

# Скачиваем только утилиту zbctl (версия должна соответствовать вашей Camunda)
# В данном случае 8.5.0, как в .env
RUN curl -L "https://github.com/camunda/zeebe/releases/download/{ZBCTL_VERSION}/zbctl" -o /usr/local/bin/zbctl \
    && chmod +x /usr/local/bin/zbctl

# Рабочая директория
WORKDIR /app

# Оставляем ENTRYPOINT пустым, чтобы команда запускалась из docker-compose
ENTRYPOINT ["sh", "-c"]