   M S B A M L   `   `   `  ���� M  I파파야연대기, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:파파야연대기파파야연대기      파파야연대기.App   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     2local clr-namespace:파파야연대기       �� 	Resources     MainMenuButtons �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  StatusTexts  InventoryButton  InventoryToolTip  InventoryToolTipName  InventoryToolTipPrice  InventoryToolTipInformation  EventTextBlock  SelectButtons 	 SelectButtonLabel 
 SettingButtons 	 track �� ImageSource	 j� Stretch 	 thumb  UpArrow  	DownArrow  VerticalScrollbar  
ThumbStyle
 ��Name J� Opacity J� SnapsToDevicePixels �� Triggers �� 
TargetName  ScrollBar_UpArrow �� CornerRadius  ScrollBar_DownArrow  ScrollBar_Track � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  SliderRepeatButton  SliderRepeatButton1  SliderThumb 
 Slider ]�Name  Horizontal_Slider  
PlusButton ��Name  CloseButton ��Name��%�  &	        &	 ?    &	 �    &	 y    &	     &	 {    &	 �    &	 0    &	 &    &		 �    &	
 T    &	 �    &	     &	 L    &	 �    '�� �    &	 �    7  &	 �	    7  &	 �
    7  &	 K    &	      7  7  7  7  7  7  &	 �    &	 h    &	 .    &	     7  7  7  &	 �    7  &	 �    &	 M    �� " ��.���  � ��$ 30(���  � �� �	#4175BEFF��  � ��$
 Left=���  � ��
 ���� ��  � ��
 ���� ��  � ��$ 3q���  � �� �� " ��.R��� #��z��._��� $
��Left=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 ���� ��  � ��
 ��  ��� " ��.���  � ��$ 20(���  � �� �#914F2F��  � ��$ Center=���  � ��$
 Left=��� " ��.���  � ��
 ���� ��  � ��$ 5q���  �@^�ShowDuration$ 60000����  � �� �� " ��.R��� #��z�� P�  �@J�IsMouseOver . . ���  � ��
 ���� �� " _�.���  � ��$	 200����  � ��$	 200����  � ��
 ���� ��  � ��
 ���� ��  �@_�	Placement$ Right=��� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 	-15,0,0,0q���  � ��$ 15(��� " ��.���  � ��$$ /Resources/PlayImages/Gold.png����  � ��$ Uniform=���  � ��$ Right=��� " ��.���  � ��$
 Wrap=���  � ��$ 	30,0,40,0q��� " ��.���  � ��$	 Top=���  �@��LineStackingStrategy$ BlockLineHeight=���  � ��$ 0����  �@��
LineHeight$ 30����  � ��$
 Wrap=���  � ��$ Visible=���  � ��$ Visible=���  � ��$ 15(��� " ��.���  � ��$ 20(���  � ��$
 Left=���  � �� Z� ��  � �� Z� ��  � ��$
 30,5q���  � �� �� " ��.R��� #��z��._��� $
��Left=�$��Center=��� " �� P�  �@J�IsMouseOver . . ���  � ��
 ���� ��  � �� �#914F2F�� " ��.���  � ��$ 20(���  � ��$ Center=���  � �� Z� ��  � �� Z� ��  � ��$ 20,10q��� $+ %/Resources/PlayImages/ScrollTrack.png��$	 UniformToFill=��� $+ %/Resources/PlayImages/ScrollThumb.png���� $- '/Resources/PlayImages/ScrollUpArrow.png��$	 UniformToFill=��� $/ )/Resources/PlayImages/ScrollDownArrow.png��$	 UniformToFill=��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P�  �@��Orientation$ Vertical=�. ���  � ��$ 40����  � ��$	 380����  � ��# �  �� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 40����  � ��$ 40����  � �� �� " n�.R��� $
 border��8��  $	 0.7Q� .  P�  �@J�IsMouseOver . . ��� $ border�� �@J�Opacity$	 1.0Q��� " ��.���  � �� �� " ��.R��� $
 border��$ 10��#��z��$��0q�8��  $	 0.7Q� .  P�  �@J�IsMouseOver . . ��� $ border�� �@J�Opacity$	 1.0Q��� " ��.���  � �� �� " ��.R��� $
 border��$ 10��#��z��$��0q�8��  $	 0.7Q� .  P�  �@J�IsMouseOver . . ��� $ border�� �@J�Opacity$	 1.0Q��� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� " ��.R��  �� $��20 ��� $��* ��� $��20 �.+��� $��1��$��10q�8��  �� |�.  $��30��$��ScrollBar.LineUpCommand��8�� �� $��2��|�.  $��30��$��ScrollBar.LineDownCommand��8�� ]� $��
PART_Track��$��1����.  �� $��3,2,3,2q�$��ScrollBar.PageUpCommand��8��  n� 8��  �� $��3,2,3,2q�$��ScrollBar.PageDownCommand��8�� �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� ���� $4 ./Resources/SettingWindowImages/SliderEmpty.png���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R���  . ���� $3 -/Resources/SettingWindowImages/SliderFill.png���� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " n�.R��� $
��Auto��$��10��$
��0,-3q����� $2 ,/Resources/SettingWindowImages/Sliderbar.png���� " ��.R��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�]� $ 
PART_Track��$��1�� �� 8��  $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge���� " ��.���  � |� .  ��  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$ 21����  � ��$	 104����  � ��8   �� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$
 Left=���  � �� �� " ��.R�� .+��� $ buttonImage��$*��$/Resources/PlayImages/PlusButton.png�� P�  �@J�IsMouseOver . . ��� $ buttonImage�� � ��$+ %/Resources/PlayImages/PlusButton2.png��P�  � {� .  . ��� $ buttonImage�� � ��$+ %/Resources/PlayImages/PlusButton2.png���� " ��.���  � ��
 ���� ��  � ��
 ���� ��  � ��$
 Left=���  � �� �� " ��.R�� .+��� $ buttonImage���� $ 
buttonText��$��- 닫기��$��20(�$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ buttonImage�� � ��$1 +/Resources/YesNoWindowImages/SealingWax.png��