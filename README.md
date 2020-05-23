# appium-flutter-driver-net-bindings
.Net Bindings for https://github.com/truongsinh/appium-flutter-driver

# STATUS: VERY MUCH A WORK IN PROGRESS!
This is a spike/poc for my needs at the moment; the 'appium-flutter-driver' that these .Net bindings rely on is (in the above authors words!) an experimental 'pre-0.1.x version'. Expect breaking changes. 

This is currently in 'Bootstrapping' mode: finders are in place, a few key session methods and a few commands. 

Android is the focus for now. 

## Version Compatibility Check
This is very much a work in progress against Appium v1.17.1 and appium-flutter-driver@0.0.23. 

To check your versions, do:

```
npm ls -g appium-flutter-driver
```

You will want to see something like this:

```
-- appium@1.17.1
  -- appium-flutter-driver@0.0.23
```

## Progress
I will use the same progress structure as 'appium-flutter-driver' to help track parity. 

### Finders
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

### Commands
| Flutter API               | System Tests | WebDriver Example                                 | Scope   | 
| ------------------------- | ------------ | ------------------------------------------------- | ------- |
| FlutterDriver.connectedTo |   :ok:       | var addressOfRemoteServer = new Uri("http://127.0.0.1:4723/wd/hub");<br>var commandExecutor = new HttpCommandExecutor(addressOfRemoteServer, TimeSpan.FromSeconds(60));<br>var webDriver = new AndroidDriver<IWebElement>(commandExecutor, capabilities);<br>var fd = new FlutterDriver(webDriver, commandExecutor) | Session |
| checkHealth               |   :ok:       | theDriver.CheckHealth()                           | Session |
| clearTextbox              |   :ok:       | theDriver.Clear(FlutterBy)                                             | Session |
| clearTimeline             |   :ok:       | theDriver.ClearTimeline()                         | Session |
| close                     |   :x:        | TODO:                                             | Session |
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
| tap                       |   :x:        | TODO:                                             | Widget  |
| traceAction               |   :x:        | (Pending appium-flutter-driver implementation)                                             | Session |
| waitFor                   |   :ok:       | theDriver.WaitFor(FlutterBy.Text("something"))                                             | Widget  |
| waitForAbsent             |   :ok:       | theDriver.WaitForAbsent(FlutterBy.Text("something"))                                             | Widget  |
| waitUntilNoTransientCallbacks|   :x:     | (Pending appium-flutter-driver implementation)                                             | Widget  |
| :question:                |   :x:        | setContext                                        | Appium  |
| :question:                |   :warning:  | getCurrentText                                    | Appium  |
| :question:                |   :warning:  | getContexts                                       | Appium  |
| :question:                |   :x:        | longTap                                           | Widget  |

## Stream of Conciousness
| Musing | Mumblings |
| ------ | --------- |
| Decorate or Isolate | I have chosen to design the solution (at present) by making  the .Net IFlutterDriver expose only the commands, methods and properties that Flutter Driver supports. <br><br>I am not using inheritance, deriving from or decorating any Selenium or Appium classes with extension methods unless I have to<br><br>Rationale: As there will likely be changes to 'appium-flutter-driver' and as there are many changes between the .Net Selenium 3 and 4 code bases, this approach seems the most resilient choice for consumers right now. <br><br>Providing the tests stick to consuming IFlutterDriver, the part most likely to change in future is the FlutterDriver construction. |

## Observations
| The Thing | The Description |
| --------- | --------------- |
| FlutterBy.XXX times out if an element is not found | Other than WaitFor (and WaitForAbsent), none of the operations seem to accept a Timeout. So if an element does not exist, for example, a Timeout exception is thrown on the call - the timeout is the value passed to the HttpCommandExecutor at construction time<br><br>I guess all of the operations would ideally accept a Timeout parameter |
| WaitFor/WaitForAbsent (NodeJs) { durationMilliseconds : ... } structure is not the correct parameter | The Flutter Driver API seems to expect timeout (seconds) as a numeric parameter; not milliseconds as a structure in the form { durationMilliseconds : ... } which the tests indicate. |
| My WaitFor/WaitForAbsent throw very generic WebDriver exceptions | Capture, wrap and rethrow |

## References
| Reference | Link |
| --------- | ---- |
| Appium Flutter Driver | https://github.com/truongsinh/appium-flutter-driver | 
| Appium Flutter Driver Test App | https://github.com/truongsinh/appium-flutter-driver/releases/download/v0.0.4/android-real-debug.apk |
| Flutter App Automation with Appium Flutter Driver<br><br>Got me up and running quickly with test app scaffolding, too | https://dev.to/netfirms/flutter-app-testing-with-appium-flutter-driver-33ko |
