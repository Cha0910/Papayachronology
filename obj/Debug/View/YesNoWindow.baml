   M S B A M L   `   `   `  ����M  I파파야연대기, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:파파야연대기파파야연대기  5   	   )    #파파야연대기.View.YesNoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:파파야연대기     5   	   $%��/Resources/Fonts/#MiraeroNormal)�5   	   ���#914F2F  � Title$  YesNoWindow��5
   	   $	��400��6   $	��600��6*    � AllowsTransparency .  � WindowStyle$
 None=�6P    � 
ResizeMode$ NoResize=�6c   
������ .��5      � ��5   
   �� 5       �� ImageSource$< 6/Resources/YesNoWindowImages/YesNoWindowBackground.png��6    j� Stretch$ UniformToFill=�6^   .+�5   
   �� $��35(�6   $��돌아가시겠습니까?��5      $��165,89,128,268q�5      �� 5   
   -   5         ��Name$ 	YesButton��5      $��153,155,347,145q�5      
������ 
������ $��30(�5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 5      �� 5      
 �� 
TargetType"
 ��6.   .R�5    "   � .+�5!   &   ��  ��Name$ buttonImage��6,   $��Uniform=�6A   �� 5"   &    ��Name$ 
buttonText��60   $
��-예��6D   ���#914F2F$��Center=�6c   $��Center=�6~   5#   #    �� Triggers 5$   "   P� 5%   &    P� Property �@J�IsMouseOver P� Value . . �5&   *   ��  �� 
TargetName$ buttonImage��61    � ��$1	 +/Resources/YesNoWindowImages/SealingWax.png��6\   �� 5'   *   $ 
buttonText��61    � ��$	  ��6Y   5(   '   5*      5,      5-      5/      �� 51   
   -   5        $ NoButton��51      $��345,155,155,145q�52      
������ 
������ $��30(�55      ��57      �� 58      " ��6   .�59      ��  � ��	 5:      �� 5;      "
 ��6.   .R�5<   "   � .+�5=   &   �� $ buttonImage��6,   $��Uniform=�6A   �� 5>   &   $ 
buttonText��60   $��
-아니오��6D   $��Center=�6P   ���#914F2F$��Center=�6�   5?   #    5@   "   P� 5A   &    �@J�IsMouseOver . . �5B   *   �� $ buttonImage��61    � ��$1	 +/Resources/YesNoWindowImages/SealingWax.png��6\   �� 5C   *   $ 
buttonText��61    � ��$	  ��6Y   5D   '   5F      5H      5I      5K      5L      5M      