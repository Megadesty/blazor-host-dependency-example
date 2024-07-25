# Hosting a Blazor app with separate project

This is a minimal repo to show the problem behind Stackoverflow question https://stackoverflow.com/questions/78790811/how-to-separate-dependency-configuration-from-ui-project-of-an-asp-net-core-blaz/

## Original question

This demo shows a problem when separate projects are used for the UI components and for the hosting.

What should be achieved:
- For the sake of a clean architecture, the `Ui` project must not have a project reference to the `Datastore` project
- Only the `Host` project, which configures dependency injection, knows both projects `Datastore` and `Ui`

The hosting works so far in the sense that the app starts and the website opens successfully and is technically working. The problem occurs with the layout since no files from the `webroot` folder can be found.

How must be the `WebApplicationBuilder` configured so that the `webroot` is found?

## Answer

The general idea of separating the `Host` project from the `Ui` project is the right way. To solve the CSS problem with the `webroot` folder, it has to taken into account that the Razor library (project `Ui`) works with isolated CSS. So instead of 

```html
    <link rel="stylesheet" href="bootstrap/bootstrap.min.css"/>
    <link rel="stylesheet" href="app.css"/>
    <link rel="stylesheet" href="Ui.styles.css"/>
    <link rel="icon" type="image/png" href="favicon.png"/>
```

this has to be used:

```html
    <link rel="stylesheet" href="_content/Ui/bootstrap/bootstrap.min.css"/>
    <link rel="stylesheet" href="_content/Ui/app.css"/>
    <link rel="stylesheet" href="_content/Ui/Ui.bundle.scp.css" />
    <link rel="icon" type="image/png" href="_content/Ui/favicon.png"/>
```

Thanks to [MrC aka Shaun Curtis](https://stackoverflow.com/users/13065781/mrc-aka-shaun-curtis) for the solution!