   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfApplication1.PropertiesWpfApplication1.Properties  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7st(clr-namespace:WpfApplication1.Properties     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5   	   $��250,250,250,250q�6    � 	Resources 5         RichGrad � Offset � Color  	SatusGrad  Std 	 Combo �� 
TargetType �� Triggers �� Binding �� ElementName �� Path	 �� Value
 �� Property �� Value  chbx ]� 
Conditions �� Property �� Value��%�  &	        &	 |     &	 �     &	 *    &	 �    �� 5	   
   .��5      � $ 0Q�6   $ White��6&   66   � 5      $ 1Q�6   $ Black��6&   66   5      �� 5   
   .��5      � $ 1Q�6   $ White��6&   66   � 5      $ 0Q�6   $ Black��6&   66   5      ��5   
   Пиши текст лол��61   �� 5   
   " ��6    5      �� 5       6   �� $ Colorse��$ SelectedItem�	 Blue6Y   .a�5      �� 
 � ��
 ��  �6B   5      �� 5       6   �� $ Colorse��$ SelectedItem�	 Red6Y   .a�5      �� 
 � ��
 �  ��6A   5      �� 5        6   �� $ Colorse��$ SelectedItem�		 Green6Y   .a�5!      �� 
 � ��
 � � �6C   5"      5$      �� 5&   
   " ��6    5'      ]� 5(       5*      �� 5+       �@J�IsMouseOver . 6C   /�5.      �� 5/      
 �@d�	IsChecked$ FalseY�66   6F   51      53      54      .��56      � -   5         �Name$
 Grid��56       � RowDefinitions 57   
   �� 58      $��20 �6   6*   �� 59      6   .+�5;   
   o� $��Stretch=�6   $	��Top=�6-   $
��Auto��6E   $��25��6R   .@�5<      m� -   5         m�Name$ MainMenu��5<      *   $WpfApplication1.Properties.Resources   m_File#��Z 6)   .@�5=      m�    m_New#��Z 6    m� Command 6B   �� *
NewCommand+6c   m� 5>         m_Save#��Z 6    6C   �� *SaveCommand+6e   m� 5?         m_Open#��Z 6    6C   �� *OpenCommand+6e   m� 5@         m_Close#��Z 6    6D   �� *CloseCommand+6g   �� 5A      5B      m� 5C         m_Edit#��Z 6   .@�5D      m�    m_Cut#��Z 6    6B   �� *
CutCommand+6c   m� 5E         m_Copy#��Z 6    6C   �� *CopyCommand+6e   m� 5F         m_Paste#��Z 6    6D   �� *PasteCommand+6g   5G      m� 5H         m_Tools#��Z 6   .@�5I      m�    m_Lang#��Z 6    6C   �� *ChangeLangCommand+6k   5J      5K      o� 5L   
   $��Stretch=�6   $	��Top=�6-   $
��Auto��6E   $��25��6R   $��1��6^   .@�5M      m� $
��Auto��6   $��35��6&    61   �� *OpenCommand+ m� Icon 5N      �� 5O      $��open.png��6   5Q      m� 5R      $
��Auto��6   $��35��6&    61   �� *SaveCommand+ 5S      �� 5T      $��save.png��6   5V      m� 5W      $
��Auto��6   $��35��6&    61   �� *CopyCommand+ 5X      �� 5Y      $��copy.png��6   5[      m� 5\      $
��Auto��6   $��35��6&    61   �� *
CutCommand+ 5]      �� 5^      $��cut.png��6   5a      �� 5b      -   5         ��Name$ Sizes��5b      $��42��6'   $
��Auto��62   ��6@   �� *	FontSizes+6b   �� 5c      -   5        $ Colorse��5c   7   #���  6   $��56��6H   $
��Auto��6S   ��6a   �� *Colors+6�   d� 5d      -   5        $��25��5d   M   6Z   d� 5e      -   5        $��25��5e   W   6d   d� 5f      -   5        $��25��5f   Q   6^   �� 5g      #���  6   $��Никогда��66   $	��Top=�6H   �� 5h      $��Смена стиля��6<   $	��Top=�6R   $��75��6j   ��6   �� *ChangeStyleCommand+6j   �� 5i      $��U��65   $	��Top=�6A   $��20��6Y   ��6   �� *UndoCommand+6Y   �� 5j      $��R��65   $	��Top=�6A   $��20��6Y   ��6   �� *RedoCommand+6Y   5k      �� 5l   
   -   5          ��Name$  mainbox��5l   E   ! J� 	AllowDrop! . $��Stretch=�5m      $��
0,25,80,42q�66   $��0,0,0,0q�6K   $��1��5n      $��Stretch=�6#   $
��Auto��6?   "" �� VerticalScrollBarVisibility$
" Auto=�5o      $# �� HorizontalScrollBarVisibility$
# Auto=�69   . �5q      /� .T�5r      J� .*�6   .*�5s      �� $ �Пиши текст лол��6   5t      5u      $ � ContextMenu$ 5v      �� 5w      .@�5x      m� #��Z 6    6G   �� *CopyCommand+6i   m� 5y      #��Z 6    6F   �� *
CutCommand+6g   m� 5z      #��Z 6    6H   �� *PasteCommand+6k   5{      5}      �� 5   
   #��[ 6   $��Stretch=�6<   $��42��6Z   $��Bottom=�6g   $��1��6�   $
��Auto��6�   .@�5�      �� -	   5        % ��Name$% StatusChars��5�      $
��Auto��6P   $��20��6]   ��6+   �� *StringNumberOfChars+6l   5�      5�      5�      