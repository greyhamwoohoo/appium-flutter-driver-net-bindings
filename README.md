# appium-flutter-driver-net-bindings
.Net Bindings for https://github.com/truongsinh/appium-flutter-driver

# STATUS: Beta (Work in Progress)
This implementation is in a beta state for my needs at the moment; the 'appium-flutter-driver' that these .Net bindings rely on is (in the above authors words!) an experimental 'pre-0.1.x version'. 

Forewarned is forearmed: Expect breaking changes on both ends! 

# Getting Started

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

## Tests as Reference
The easiest way to get started is to look at the .SystemTests project: they will always be the source of truth on how these bindings work. You will need to build the test app and change the path. 

See TestBase.cs for how to manage the lifecycle of a FlutterDriver. 

Appium... can be a bit traumatic to set up if you have never used it before. I recommend setting up Appium separately before trying to use these driver bindings!

## Test App
I wrote a simple Flutter test application that can be found in the Appium.Flutter.TestApp/howdi_welt folder. 

All tests rely on that application being built. 

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

## Observations
| The Thing | The Description |
| --------- | --------------- |
| FlutterBy.XXX times out if an element is not found | Other than WaitFor (and WaitForAbsent), I am not sure if the other appium-flutter-driver operations accept a Timeout (they seem to wait forever and obviously timeout based on the parameters passed to the HttpCommandExecutor). <br><br>I guess all of the operations would ideally accept a Timeout parameter; maybe they do. Will investigate more. |
| appium-flutter-driver WaitFor/WaitForAbsent (NodeJs) tests do not seem to match the expectations of the implementation | The appium-flutter-driver works well if a 'seconds' parameter is passed in; however, if the structure is passed in (as the appium-flutter-driver NodeJS tests would indicate - { durationMilliseconds: xxx }) then the driver throws an exception. Will investigate further and raise an issue upstream. <br><br>At the moment, I hide the implementation problem by always sending a seconds parameter to appium-flutter-driver |
| My WaitFor/WaitForAbsent throw very generic WebDriver exceptions | Capture, wrap and rethrow |
| appium-flutter-driver .touchAction does not seem to work correctly for multiple actions | I was unable to get press, release and wait to work when issued in sequence; including using the NodeJS tests. Will investigate. |

## References
| Reference | Link |
| --------- | ---- |
| Appium Flutter Driver | https://github.com/truongsinh/appium-flutter-driver | 
| Flutter App Automation with Appium Flutter Driver<br><br>Got me up and running quickly with test app scaffolding, too | https://dev.to/netfirms/flutter-app-testing-with-appium-flutter-driver-33ko |
