   M S B A M L   `   `   `  ���� M  I파파야연대기, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:파파야연대기.View파파야연대기.View  ,    &파파야연대기.View.NewGameCaution   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:파파야연대기.View     $%��/Resources/Fonts/#MiraeroNormal)����#914F2F  � Title$  NewGameCaution��$	��400��$	��600�� � AllowsTransparency .  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
������ .��� ����  �� ImageSource$< 6/Resources/YesNoWindowImages/YesNoWindowBackground.png�� j� Stretch$ UniformToFill=�.+��� $��25(�$M��G이미 세이브 파일이 있습니다.
     계속하시겠습니까?��$��153,83,104,264q�$��Center=�$��Center=�$	��343���� -    ��Name$ 	YesButton��$��153,155,347,145q�
������ 
������ $��30(�����  �� 
TargetType" ��.���  �� Property � ��	 �� Value	 �� 
 �� 
TargetType"
 ��.R�� .+���  ��Name$ buttonImage��$��Uniform=���  ��Name$ 
buttonText��$
��-예�����#914F2F$��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ buttonImage�� � ��$1	 +/Resources/YesNoWindowImages/SealingWax.png���� $ 
buttonText�� � ��$	  ���� -   $ NoButton��$��345,155,155,145q�
������ 
������ $��30(����� " ��.���  � ��	 �� "
 ��.R�� .+��� $ buttonImage��$��Uniform=��� $ 
buttonText��$��
-아니오��$��Center=����#914F2F$��Center=� P�  �@J�IsMouseOver . . ��� $ buttonImage�� � ��$1	 +/Resources/YesNoWindowImages/SealingWax.png���� $ 
buttonText�� � ��$	  ��