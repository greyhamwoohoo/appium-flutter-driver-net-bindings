# appium-flutter-driver-net-bindings (Beta)
.Net Bindings for https://github.com/truongsinh/appium-flutter-driver. 

This is tested only with these versions:

```
npm ls -g appium-flutter-driver

+-- appium@1.18.0
  `-- appium-flutter-driver@0.0.23
```

## Status - Beta (Work in Progress)
The 'appium-flutter-driver' that these .Net bindings rely on is (in the original authors words!) an experimental 'pre-0.1.x version'. 

Forewarned is forearmed: Expect breaking changes on both ends! 

### Builds
Several builds are included: 

| Build | Result | Description |
| ----- | ------ | ----------- |
| release.yml | [![Build Status](https://greyhamwoohoo.visualstudio.com/Public-Automation-Examples/_apis/build/status/Appium%20Flutter%20Driver/appium-flutter-driver-net-master?branchName=master)](https://greyhamwoohoo.visualstudio.com/Public-Automation-Examples/_build/latest?definitionId=28&branchName=master) | Produces the NuGet Package and publishes to NuGET (Beta only) | 
| execute-system-tests.yml | [![Build Status](https://greyhamwoohoo.visualstudio.com/Public-Automation-Examples/_apis/build/status/appium-flutter-driver-net-bindings-system-tests?branchName=master)](https://greyhamwoohoo.visualstudio.com/Public-Automation-Examples/_build/latest?definitionId=31&branchName=master) | (Appium) Target a [Flutter Test App](https://github.com/greyhamwoohoo/appium-flutter-driver-net-bindings-test-app) deployed to an Android AVD running in the Azure DevOps MacOS Hosted Pool |

### Known Issues
These are known issues I have encountered so far. 

| Issue | Discussion |
| ------|------------|
| Not all appium-flutter-driver features are supported | Correct. These C# bindings will be updated over time; see Progress below more the current state of parity with appium-flutter-driver |
| FlutterBy.XXX times out (based on HttpCommandHandler timeout) if an element cannot be found | I have not found a way of specifying timeouts to appium-flutter-driver for individual commands. |
| Upstream appium-flutter-driver does not seem to work with multiple .touchActions | I was not able to get a sequence of actions to work correctly - such as press; wait; release including using their nodeJs tests. Will continue to investigate. |
| Upstream appium-flutter-driver does not seem to work with descendant/ancestor finders | I was not able to get any of these calls working - so have not included in the C# bindings for now |

# Getting Started

## Version Compatibility Check
This is very much a work in progress against Appium v1.17.1 and appium-flutter-driver@0.0.23. 

To check your versions, do:

```
npm ls -g appium-flutter-driver
```

You will want to see something like this:

```
+-- appium@1.18.0
  `-- appium-flutter-driver@0.0.23
```

## Tests as Reference
The easiest way to get started is to look at the .SystemTests project: they will always be the source of truth on how these bindings work. You will need to build the test app and change the path. 

See TestBase.cs for how to manage the lifecycle of a FlutterDriver.

`Appium`... can be a bit traumatic to set up if you have never used it before. I recommend setting up Appium separately before trying to use these driver bindings!

## Test App
I wrote a simple Flutter test application that can be found and built at https://github.com/greyhamwoohoo/appium-flutter-driver-net-bindings-test-app. That will produce the .apk we need to use in the .SystemTests. 

All .SystemTests rely on that application being built. 

# Progress
I will use the same progress structure as 'appium-flutter-driver' to help track parity. 

## Finders
| Flutter Driver API | Status | Unit Tests | System Tests |
| ------------------ | ------ | ---------- | ------------ |
| ancestor           |   :x:  | :x:        | :x:          |
| bySemanticsLabel   |   :ok: | :ok:       | :ok:          |
| bySemanticsLabel (Regular Expression)  |   :x:  | :x:        | :x:          |
| byTooltip          |   :ok: | :ok:       | :ok:          |
| byType             |   :ok: | :ok:       | :ok:          |
| byValueKey         |   :ok: | :ok:       | :ok:          |
| descendent         |   :x:  | :x:        | :x:          |
| pageBack           |   :ok: | :ok:       | :ok:          |
| text               |   :ok: | :ok:       | :ok:          |

## Commands
| Flutter API               | System Tests | WebDriver Example                                 | Scope   | 
| ------------------------- | ------------ | ------------------------------------------------- | ------- |
| FlutterDriver.connectedTo |   :ok:       | var addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");<br>var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(60));<br>var webDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);<br>var fd = new FlutterDriver(webDriver, commandExecutor) | Session |
| checkHealth               |   :ok:       | theDriver.CheckHealth()                           | Session |
| clearTextbox              |   :ok:       | theDriver.Clear(FlutterBy)                                             | Session |
| clearTimeline             |   :ok:       | theDriver.ClearTimeline()                         | Session |
| close                     |   :ok:       | theDriver.Close() (calls .Close() and .Quit() on the underlying driver)                                           | Session |
| enterText                 |   :ok:       | theDriver.SendKeys(FlutterBy)                                             | Session |
| forceGC                   |   :ok:       | theDriver.ForceGC()                               | Session |
| getBottomLeft             |   :ok:        | theDriver.GetBottomLeft(FlutterBy.Text("theText"))                                            | Widget  |
| getBottomRight            |   :ok:       | theDriver.GetBottomRight(FlutterBy.Text("theText"))                                             | Widget  |
| getCenter                 |   :ok:        | theDriver.GetCenter(FlutterBy.Text("theText"))                                             | Widget  |
| getRenderObjectDiagnostics|   :ok:       | theDriver.GetRenderObjectDiagnostics(FlutterBy.ValueKey("counter"), includeProperties: true, subtreeDepth: 1)                                             | Widget  |
| getRenderTree             |   :ok:       | theDriver.GetRenderTree()                         | Session |
| getSemanticsId            |   :ok:       | theDriver.GetSemanticsId(FlutterBy.ValueKey("counter"))                                        | Widget  |
| getText                   |   :ok:       | theDriver.GetText(counterTextFinder)       | Widget  |
| getTopLeft                |   :ok:       | theDriver.GetTopLeft(FlutterBy.Text("theText"))                                             | Widget  |
| getTopRight               |   :ok:        | theDriver.GetTopRight(FlutterBy.Text("theText"))                                             | Widget  |
| getVmFlags                |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| getWidgetDiagnostics      |   :x:        | (Pending appium-flutter-driver implementation)                                            | Widget  |
| requestData               |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| runUnsyncrhonized         |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| screenshot                |   :ok:        | theDriver.Screenshot(thePath)                                             | Session |
| screenshot                |   :ok:        | var bytesForPng = theDriver.Screenshot()                                             | Session |
| scroll                    |   :x:        | TODO:                                             | Widget  |
| scrollIntoView            |   :x:        | TODO:                                             | Widget  |
| scrollUntilVisible        |   :x:        | TODO:                                             | Widget  |
| setSemantics              |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| setTextEntryEmulation     |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| startTracing              |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| stopTracingAndDownloadTimeline|   :x:    | (Pending appium-flutter-driver implementation)                                             | Session |
| tap                       |   :ok:       | theDriver.Click(FlutterBy by)                                             | Widget  |
| tap                       |   :ok:       | new FlutterTouchActions().Tap(); new FlutterTouchActions().LongPress();                                             | Widget  |
| traceAction               |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| waitFor                   |   :ok:       | theDriver.WaitFor(FlutterBy.Text("something"))                                             | Widget  |
| waitForAbsent             |   :ok:       | theDriver.WaitForAbsent(FlutterBy.Text("something"))                                             | Widget  |
| waitUntilNoTransientCallbacks|   :x:     | (Pending appium-flutter-driver implementation)                                             | Widget  |
| :question:                |   :x:        | setContext                                        | Appium  |
| :question:                |   :warning:  | getCurrentText                                    | Appium  |
| :question:                |   :warning:  | getContexts                                       | Appium  |
| :question:                |   :x:        | longTap                                           | Widget  |

# Stream of Conciousness
| Musing | Mumblings |
| ------ | --------- |
| Decorate or Isolate | I have chosen to design the solution (at present) by making  the .Net IFlutterDriver expose only the commands, methods and properties that Flutter Driver supports. <br><br>I am not using inheritance, deriving from or decorating any Selenium or Appium classes with extension methods unless I have to<br><br>Rationale: As there will likely be changes to 'appium-flutter-driver' and as there are many changes between the .Net Selenium 3 and 4 code bases, this approach seems the most resilient choice for consumers right now. <br><br>Providing the tests stick to consuming IFlutterDriver, the part most likely to change in future is the FlutterDriver construction. |

## References
| Reference | Link |
| --------- | ---- |
| Appium Flutter Driver | https://github.com/truongsinh/appium-flutter-driver | 
| Flutter App Automation with Appium Flutter Driver<br><br>Got me up and running quickly with test app scaffolding, too | https://dev.to/netfirms/flutter-app-testing-with-appium-flutter-driver-33ko |
