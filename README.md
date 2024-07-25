# Hosting a Blazor app with separate project

This demo shows a problem when separate projects are used for the UI components and for the hosting.

What should be achieved:
- For the sake of a clean architecture, the `Ui` project must not have a project reference to the `Datastore` project
- Only the `Host` project, which configures dependency injection, knows both projects `Datastore` and `Ui`

The hosting works so far in the sense that the app starts and the website opens successfully and is technically working. The problem occurs with the layout since no files from the `webroot` folder can be found.

How must be the `WebApplicationBuilder` configured so that the `webroot` is found?
