using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            /* SimpleRemoteControl remote = new SimpleRemoteControl();
             Light light = new Light();
             GarageDoor garageDoor = new GarageDoor();
             LightOnCommand lightOn = new LightOnCommand(light);
             GarageDoorOpenCommand doorOpen = new GarageDoorOpenCommand(garageDoor);

             remote.SetCommand(lightOn);
             remote.ButtonWasPressed();

             remote.SetCommand(doorOpen);
             remote.ButtonWasPressed();
         */

            /*RemoteControl remoteControl = new RemoteControl();
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            //CeilingFan ceilingFan = new CeilingFan(“Living Room”);
            GarageDoor garageDoor = new GarageDoor(“”);
            Stereo stereo = new Stereo(“Living Room”);

            LightOnCommand livingRoomLightOn =
            new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff =
            new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn =
            new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff =
            new LightOffCommand(kitchenLight);

            CeilingFanOnCommand ceilingFanOn =
            new CeilingFanOnCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOff =
            new CeilingFanOffCommand(ceilingFan);
            GarageDoorUpCommand garageDoorUp =
            new GarageDoorUpCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown =
            new GarageDoorDownCommand(garageDoor);
            StereoOnWithCDCommand stereoOnWithCD =
            new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOff =
            new StereoOffCommand(stereo);

            remoteControl.setCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.setCommand(1, kitchenLightOn, kitchenLightOff);
            remoteControl.setCommand(2, ceilingFanOn, ceilingFanOff);
            remoteControl.setCommand(3, stereoOnWithCD, stereoOff);

            Console.WriteLine(remoteControl);
            remoteControl.onButtonWasPushed(0);
            remoteControl.offButtonWasPushed(0);
            remoteControl.onButtonWasPushed(1);
            remoteControl.offButtonWasPushed(1);
            remoteControl.onButtonWasPushed(2);
            remoteControl.offButtonWasPushed(2);
            remoteControl.onButtonWasPushed(3);
            remoteControl.offButtonWasPushed(3);*/

            RemoteControl remoteControl = new RemoteControl();
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            GarageDoor garageDoor = new GarageDoor("");
            Stereo stereo = new Stereo("Living Room");

            LightOnCommand livingRoomLightOn =
            new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff =
            new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn =
            new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff =
            new LightOffCommand(kitchenLight);

            // Controls for a marco command aka multiple commands at once
            Light macroLight = new Light("Macro Light");
            Light otherMacroLight = new Light("Other Macro Light");

            LightOnCommand macroLightOn = new LightOnCommand(macroLight);
            LightOnCommand otherMacroLightOn = new LightOnCommand(otherMacroLight);
            LightOffCommand macroLightOff = new LightOffCommand(macroLight);
            LightOffCommand otherMacroLightOff = new LightOffCommand(otherMacroLight);

            remoteControl.setCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.setCommand(1, kitchenLightOn, kitchenLightOff);

            Console.WriteLine(remoteControl.toString());
            remoteControl.onButtonWasPushed(0);
            remoteControl.offButtonWasPushed(0);
            remoteControl.onButtonWasPushed(1);
            remoteControl.offButtonWasPushed(1);
            remoteControl.onButtonWasPushed(2);
            remoteControl.offButtonWasPushed(2);
            remoteControl.onButtonWasPushed(3);
            remoteControl.offButtonWasPushed(3);
            remoteControl.onButtonWasPushed(0);
            remoteControl.undoButtonWasPushed();

            ICommand[] partyOn = {macroLightOn, otherMacroLightOn};
            ICommand[] partyOff = {macroLightOff, otherMacroLightOff};

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);
            remoteControl.setCommand(2, partyOnMacro, partyOffMacro);

            remoteControl.onButtonWasPushed(2);
            remoteControl.offButtonWasPushed(2);
            remoteControl.undoButtonWasPushed();
        }
    }
}
