#addin "wk.StartProcess"

using PS = StartProcess.Processor;

Task("Watch").Does(() => {
    PS.StartProcess("dotnet watch --project src/EventTracker run");
});

Task("Build-JS").Does(() => {
    PS.StartProcess("parcel build client/index.ts");
});

var target = Argument("target", "Watch");
RunTarget(target);