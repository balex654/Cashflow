FROM node:18 AS builder

WORKDIR /app
COPY package.json ./
COPY package-lock.json ./
COPY . .
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /app/www .
CMD ["nginx", "-g", "daemon off;"]