   M S B A M L   `   `   `  ����O  KPythonConsoleControl, Version=1.1.2.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:PythonConsoleControl;assembly=PythonConsoleControlPythonConsoleControl  5   	    IronPythonConsole"   IronPythonConsole.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ` \ICSharpCode.AvalonEdit, Version=4.0.0.5949, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   Nconsole@clr-namespace:PythonConsoleControl;assembly=PythonConsoleControl  5   	   s oSystem.Windows.Controls.WpfPropertyGrid, Version=2010.11.10.0, Culture=neutral, PublicKeyToken=be4b71144cd8a3e5@pg7http://schemas.denisvuyka.wordpress.com/wpfpropertygrid  5   	     � Title$  IronPython Console��5   	   $	��350��6$   $	��692��61   .��5      �  � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $
��Auto �6   �� 5      $	��30* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��0��6   .+�5      3   -PythonConsoleControl.IronPythonConsoleControl  -   5        $��console��5   /   6@   5      �� 5   
   $��1��6   $��10��6$   $��Center=�60   $��Stretch=�6K   6k   ]� 5   
   $��2��6   $��0��6!   .+�5      c� $	��Top=�6    � 	Resources 5       �� 
TargetType �� Triggers �� Binding �� RelativeSource �� AncestorType	 �� AncestorLevel
 �� Path �� Value �� Property �� Value��%�   '��       �� 5      " ��6    5      �� 5       6*   ��  �� " ��$	 1��$
 	IsEnabled�	 False6�   .a�5   "   ��  �@J�Opacity$
 0.30Q�6<   5       5"      5#      .@�5$      �� -   5        .��5%      �� $��Images/Open.png��6   $��16��65    � ToolTip$
 Open��6A   5&      �� 5'      -   5        .��5(      �� $��Images/Save.png��6   $��16��65   $
 Save��6A   5)      �� 5*      �� 5+      $	��Cut��6   .��5,      �� $��Images/Cut.png��6   $��16��64   $	 Cut��6@   5-      �� 5.      $
��Copy��6   .��5/      �� $��Images/Copy.png��6   $��16��65   $
 Copy��6A   50      �� 51      $��Paste��6   .��52      �� $��Images/Paste.png��6   $��16��66   $ Paste��6B   53      �� 54      $��Delete��6   .��55      �� $��Images/Delete.png��6   $��16��67   $ Delete��6C   56      �� 57      �� 58      $
��Undo��6   .��59      �� $��Images/Undo.png��6   $��16��65   $
 Undo��6A   5:      �� 5;      $
��Redo��6   .��5<      �� $��Images/Redo.png��6   $��16��65   $
 Redo��6A   5=      �� 5>      �� 5?      $ 	Word Wrap��6V    d� 	IsChecked 6   ��  �� ElementName$ 
textEditor��$
 WordWrap�.��5@      �� $��Images/WordWrap.png��6   $��16��69   5A      �� 5B      $ Add Line Numbers��6]    6   �� $ 
textEditor��$
 ShowLineNumbers�.��5C      �� $��16��6     �� TextAlignment$ Center=�6+   #6E   5D      �� 5E      $ Show End of Line��6c    6   �� $ 
textEditor��$
 Options.ShowEndOfLine�.��5F      �� $��16��6    $ Center=�6+   ¶6E   5G      �� 5H      �� 5I      -   5        .��5J      �� $��Images/Run.png��6   $��16��64   $	 Run��6@   5K      �� 5L      �� 5M      -   5        $ API Help��5M   /   .��5N      �� $��Images/Help.png��6   $��16��65   5O      5P      � 5Q      $��Bottom=�6   .+�5R      '  !ICSharpCode.AvalonEdit.TextEditor  -   5        $��
textEditor��5S      $��Consolas)�5T      $
��10pt(�5U         Text. 5V      ge# IronPython Pad. Write code snippets here and F5 to run. If code is selected, only selection is run.5W      5X      5Y      9� 5Z   
   -   5        $��expander��5Z      $��1��6#   $��3��63   $��0 0 0 0q�6D   $��Right=�6U    9� ExpandDirection$
 Left=�6q   $	��300��6�   .��5\      ]� .+�5]      �� -   5        $��propertyGridComboBox��5]      $	��Top=�67    �� SelectedIndex$ 0��5^      .@�5_      �� .��6#   	Console6,   �� 5`      .��6#   Pad6(   5a      :  4System.Windows.Controls.WpfPropertyGrid.PropertyGrid  5b      -	   5        $��propertyGrid��5b   "   5c      5g      5h      5i      5j      