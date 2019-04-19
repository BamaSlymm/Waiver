# DPA IDS Waiver Site

## 1. Introduction

This project is a rewrite-redesign of the existing DPA Waiver site. It has additional functionality that the [prior site](https://idsonline.colorado.gov/Forms/WaiverRequestSystem/) does not have. It uses [.Net Core](https://www.microsoft.com/net/download) and [Asp.Net Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1) as the framework. It also utilizes [EF.Core](https://docs.microsoft.com/en-us/ef/core/). 

The application can be dockerized and made available on GCP, AWS and/or AWS. Currently the application is designed to be deployed on [App Engine Flexible Environment](https://cloud.google.com/appengine/docs/flexible/). GAE Flex takes care of dockerization, deployment as well as certificate generation.


## 2. Design  

The application is designed to be run from a container. There is no reason to setup a Windows environment to deploy it. The application can be developed/run from Windows/Mac/Linux. The current editor of choice is [VS Code](https://code.visualstudio.com/). 

The environment uses [Google Cloud Store](https://cloud.google.com/storage/docs/) to persist the attachments. The e-mail system currently uses [SendGrid](https://sendgrid.com/) which is on a free tier for 100 emails a day. There is also a separate SMTP branch available if desired.

For VS Code, the [Omnisharp](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp), [Beautify](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode), [Project Snippets](https://marketplace.visualstudio.com/items?itemName=rebornix.project-snippets), [IntelliSense for CSS class names in HTML plugins](https://marketplace.visualstudio.com/items?itemName=Zignd.html-css-class-completion)
 are recommended.

## 3. Compile

Download [.Net Core SDK](https://www.microsoft.com/net/download). Navigate to project directory DPAWaiver, issue 

```sh
dotnet restore
dotnet build
dotnet run
```

Alternatively, use the VS Code, Omnisharp plugin to automatically debug and build.

## 4. Test

There is DPAWaiver.Tests directory for running tests. You can use it to test certain logic such EF.Core or ASP.Net Core if desired. More tests can be added if desired.

## 5. Deploy

There is [app.yaml](DPAWaiver/app.yaml) file available for deploying to GAE Flex. The VS Code contains a task to deploy to GAE. Basically to deploy GAE, the user has to build using a Release profile. 

```sh
dotnet publish -c Release
cd DPAWaiver/bin/Release/netcoreapp2.1/publish && gcloud app deploy --promote --project=dpa-waiver --version YYYYMMDD 
```

With the GAE Flex, after deployment, code can be backed out by simply switching to older production code. The database changes, if any, have to be backed out separately if needed. 

### 5.1 app.yaml

The [app.yaml](https://storage.cloud.google.com/project-settings-dpa-waiver/app.yaml?folder&organizationId) in Google Console Project contains the production parameters. 

### 5.2 client.pfx / Database access
The [client.pfx](https://storage.cloud.google.com/project-settings-dpa-waiver/client.pfx?folder&organizationId) is used to establish secure identity with the Google Cloud SQL. The certificate is needed to be included in the docker image. The username and password on their own are not enough to establish connection. The client.pfx needs to be copied to DPAWaiver directory before deployment. Use this command to recreate client.pfx file once it has been revoked or changed or removed.

```sh
$ openssl pkcs12 -export -out client.pfx -inkey client-key.pem -in client-cert.pem -certfile server-ca.pem
```

The client certificate can be created and downloaded using the [Google Console Application](https://cloud.google.com/sql/docs/postgres/configure-ssl-instance).

### 5.3 Storage Access

The cloud storage uses a JSON file [test-cloud-storage.json](https://storage.cloud.google.com/project-settings-dpa-waiver/test-cloud-storage.json?folder&organizationId) for development deployment. The file then gets pulled into the docker image created. A similar file needs to be created for deployment to production. 

 [Service accounts](https://cloud.google.com/compute/docs/access/service-accounts) can be created by going to this [URL](https://console.cloud.google.com/iam-admin/serviceaccounts?project=dpa-waiver). To create a new service account and credentials, follow the [instructions on Google Web Site](https://cloud.google.com/iam/docs/creating-managing-service-accounts). The service account should have to be enable for DataStore access. It also needs to be authorized for the specific bucket.

## 6. Security & CSR

Currently the GAE takes care of creating the certificate. In the future, if this changes, a certificate needs to be pushed into the docker image.

## 7. Miscellaneous

* [Getting started with Asp.Net Core 2.1](https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-2.1&tabs=windows)
* [Getting started with .Net Core](https://docs.microsoft.com/en-us/dotnet/core/get-started?tabs=windows)
* [EF Core](https://docs.microsoft.com/en-us/ef/core/)
* [How to Scaffold Asp.Net Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-2.1&tabs=netcore-cli)
* [Asp.Net Core Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.1&tabs=visual-studio-code)
* [Scaffolding Razor Pages for EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.1&tabs=netcore-cli)


