.DEFAULT_GOAL := all

NAME := axisandallies
VERSION := 0.1.0
PROFILE ?= dev
ENV_FILE ?= server/config/.env
TIMESTAMP := $(shell date +%s)
# Directory for root certificates on Linux
ROOT_CERT_DIR := /etc/ssl/certs
# Target directory to hold build artifacts and working files
DIST_BASE_DIR := target
# Target directory to hold compiled sources
DIST_SOURCE_DIR := $(DIST_BASE_DIR)/src
# Target directory for TLS certificates
DIST_CERT_DIR := $(DIST_SOURCE_DIR)/cert
# Target directory to hold markers for indicating successful build steps
DIST_MARKER_DIR := $(DIST_BASE_DIR)/marker
# Target directory to hold docker-build artifacts
DIST_BUILD_DIR := $(DIST_BASE_DIR)/build
# Target directory for copy of root certificates
DIST_ROOT_CERT_DIR := $(DIST_BUILD_DIR)$(ROOT_CERT_DIR)
# Target directory to hold deployment zip files for upload to AWS
DIST_DEPLOY_DIR := $(DIST_BASE_DIR)/deploy
# File name for deployment artifact
ARTIFACT_NAME := $(NAME)_$(VERSION)_$(TIMESTAMP)

export NAME
export VERSION
export PROFILE
export ENV_FILE

# Create target directories
$(DIST_BASE_DIR) \
$(DIST_SOURCE_DIR) \
$(DIST_MARKER_DIR) \
$(DIST_BUILD_DIR) \
$(DIST_ROOT_CERT_DIR) \
$(DIST_DEPLOY_DIR) \
$(DIST_CERT_DIR):
	@mkdir -p $@

### Standard Rules ###

.PHONY: all
all: deps build run

.PHONY: deps
deps: server-deps

.PHONY: build
build: server-build

.PHONY: run
run: build
	@cp $(ENV_FILE) $(DIST_SOURCE_DIR)/.env
	@cp -R cert $(DIST_SOURCE_DIR)
	cd $(DIST_SOURCE_DIR) && ./$(NAME)

.PHONY: test
test:
	cd ./server && go test -v -timeout 30s -run '' ./...

.PHONY: clean
clean:
	@rm -rf ./$(DIST_BASE_DIR)

### Server (Go) Rules ###

.PHONY: server-run
server-run: server-build
	@cp $(ENV_FILE) $(DIST_SOURCE_DIR)/.env
	@cp -R cert $(DIST_SOURCE_DIR)
	cd $(DIST_SOURCE_DIR) && ./$(NAME)

.PHONY: server-deps
server-deps:
	cd ./server && go get -v

.PHONY: server-build
server-build: server/*.go | $(DIST_SOURCE_DIR)
	cd ./server && go build -v -o $(NAME) -ldflags "-X main.VERSION=$(VERSION)"
	@mv server/$(NAME) $(DIST_SOURCE_DIR)/$(NAME)

### Certificate Management ###

.PHONY: certificate-build
certificate-build: cert/server.crt cert/server.key
cert/server.crt cert/server.key:
	make -C cert
$(DIST_CERT_DIR)/server.crt: cert/server.crt | $(DIST_CERT_DIR)
	@cp $< $@
$(DIST_CERT_DIR)/server.key:  cert/server.key | $(DIST_CERT_DIR)
	@cp $< $@
