# Employee Benefit Manager Example

## Server
- Server code is a .NET Core Api implementing GraphQL for querying and saving data
- Visual Studio 2017 / .NET Core 2.1

## Client
- Client application is Angular communicating to the server side Api
- Visual Studio Code / angular cli
- Node for Windows v10.6.0
- NPM for Windows v6.4.1

## Known Missing Components
- Security: originally planned to implement Auth0 for token based authorization and authentication
- Data Store: current data store is an in memory concurrent dictionary

## Live Demo
- https://ebm-client.cfapps.io
- Live demo is running on Pivotal Web Services
- Due to in memory storage of data, occassional restarting of the service will cause data to be removed
