NAME := axisandallies
VERSION := 1.0.0
PROFILE ?= dev
ENV_FILE ?= server/config/.env
BUILD_DIR := bin

.PHONY: setup
setup:
	@cp server/config/$(PROFILE).env $(ENV_FILE)

.PHONY: deps
deps:
	cd ./server && go get -v

.PHONY: build
build:
	cd ./server && go build -v -o ../bin/$(NAME) -ldflags "-X main.VERSION=$(VERSION)"
	cp ./server/config/$(PROFILE).env ./bin/.env

.PHONY: run
run: build
	cd ./$(BUILD_DIR) && ./$(NAME)

.PHONY: test
test:
	cd ./server && go test -v -timeout 30s -run '' ./...

.PHONY: clean
clean:
	@rm -rf ./$(BUILD_DIR)
