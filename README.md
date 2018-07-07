## VS Code Event Tracker

```
dotnet add package wk.EventTracker
```

## Usage

```
wk-event-tracker
wget http://localhost:7777/vscode.js --output-document ~/.event-tracker.js
```

## appsettings.json

```
"vscode_custom_css.statusbar": true,
"vscode_custom_css.policy": true,
"vscode_custom_css.imports": [
    "file:///Users/wk/.event-tracker.js"
],
```