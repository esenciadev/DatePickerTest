## Demo of Xamarin.Forms UIDatePicker bug on iphone 11 Pro

This repo demonstrates a minimal reproduction of a date picker rendering bug which only occurs on iPhone 11 plus - on the simulator and a 7 plus it renders correctly.

11 Pro:
![11 Pro][https://github.com/esenciadev/DatePickerTest/11pro.png]

7 Plus:
![7 Plus][https://github.com/esenciadev/DatePickerTest/7plus.png]

I have tried several combinations of margin, stack layout options, and fiddling with the UIDatePicker properties, all to no avail. I don't know if the bug is present in a 'pure' Xamarin iOS project (sans-Forms).
