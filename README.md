# Frends.SendGrid

frends Community Task for SendGrid

[![Actions Status](https://github.com/CommunityHiQ/Frends.SendGrid/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.SendGrid/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.SendGrid) [![License: UNLICENSED](https://img.shields.io/badge/License-UNLICENSED-yellow.svg)](https://opensource.org/licenses/UNLICENSED) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [SendGrid](#SendGrid)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.SendGrid

# Tasks

## SendEmail

Sends email with the usage of SendGrid API.


### Parameters

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| AuthorizationToken | `string` | API key provided by SendGrid | `SG.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx` |
| Sender | `string` | Email address from whom the email has been sent | `sender@example.com` |
| Recipients | `string[]` | Array of addresses to whom the email will be sent | `recipient@example.com` |
| Subject | `string` | Subject of the email | `Example subject` |
| Message | `string` | Message of the email in `html` format | `Hello!<br>This is example<br>Best regards!` |
| Attachments | `Attachments[]` | Array of Attachments type objects ||

#### Attachments

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| ContentType | `string` | MIME type of attachment | `application/json` |
| FileName | `string` | File name | `example.txt` |
| Content | `string` | Base64 string of attached file| |

### Returns

A result object with parameters.

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| StatusCode | `string` | HTTP Status Code recieved from server | `202` |
| Body | `string` | Body of message recieved from server | |
| Headers | `string` | String of headers recieved with message | |

# Building

Clone a copy of the repository

`git clone https://github.com/CommunityHiQ/Frends.SendGrid.git`

Rebuild the project

`dotnet build`

Run tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repository on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 0.0.1   | Development still going on |
