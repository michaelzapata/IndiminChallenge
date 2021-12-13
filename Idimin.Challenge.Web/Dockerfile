FROM node:14.15.4-alpine

#create destination directory
RUN mkdir -p /app
WORKDIR /app

#COPY ["Idimin.Challenge.Web/package.json", "/app"]
#COPY ["./package.json", "/app"]

#update and install dependency
RUN apk update && apk upgrade
RUN apk add git

#copy the app, note .dockerignore
COPY ./Idimin.Challenge.Web /app
RUN npm install

#build necessary, even if no static files are needed,
RUN npm run build

#set app serving to permissive / assigned
#ENV HOST 0.0.0.0

#expose 8000 on container
EXPOSE 3000

ENV NUXT_HOST=0.0.0.0
ENV NUXT_PORT=3000

WORKDIR /app
CMD ["npm", "start"]