# SCS Telemetry Server
A telemetry server for ETS2 & ATS, utilizing a Web Server & Serial Access in order to help create new applications!

Using the spectacular [SCS-SDK-Plugin](https://github.com/RenCloud/scs-sdk-plugin) by RenCloud!

Video example of the Arduino Server Running [YouTube](https://youtu.be/5VJYbR_MEM0)

Images of the V0.0.1A User Interface [Imgur](https://imgur.com/a/qS7otsD)

Reddit Showcase #1 Post [Reddit](https://www.reddit.com/r/trucksim/comments/gd1pgt/arduinoscstelemetry_showcase_1/)

### -- Features --

* Connects to ETS2 & ATS Telemetry
* Fully up-to-date with all SDK Changes
* Output JSON Formatted stream over Serial (Work in Progress, bugs!)
* User UI showing current Information
* Can determine the closest City & Country to the users truck! (using the Co-Ordinates given ingame)

### -- File Structure --
<pre>
├── Publish (Do not use this yet, not functional)
├── SCS-Telemetry-Server-Arduino
│    ├── For displaying data on a 3.5" TFT Screen
├── SCS-Telemetry-Server
│    ├── The main program!
├── SCSSdkClient
│    ├── The .dll compiler to connect to the Shared Memory (from RenCloud)
├── scs-telemetry
│    ├── The .dll compiler that actually connects to the game and produces data
├── scs_sdk_1_11
│    ├── The SDK this program currently uses (Latest)
</pre>
Items shown in *italic* will be included as standard but can be disabled in Settings!
### -- To do --
- [x] ~~Rename to "SCS Telemetry Server" (Remove soley Arduino use [Decided to be a little more inclusive!])~~
- [ ] Start the documentation/Wiki
- [ ] *Webserver API to stream JSON Telemetry*
  * - [ ] Combined JSON Streams
  * - [ ] Individual Streams
- [ ] *Serial Connection*
  * - [ ] Only send changes
  * - [ ] Send all (Nearly functional - Missing a few features)
- [ ] *Create Game-Overlay*
  * - [ ] Break Time!
  * - [ ] Driving Hours (Running out, updates)
  * - [ ] Damage
  * - [ ] Delivery Updates
- [ ] *Driving Hours Management*
  * - [ ] Length between breaks
  * - [ ] Max daily driving hours
- [ ] Create Settings Tab
- [ ] *[ETS-Local-Radio](https://github.com/Koenvh1/ets2-local-radio) Compatibility (Pull Request Sent)*
- [ ] Keyboard & Game Controller Support (in-game)
