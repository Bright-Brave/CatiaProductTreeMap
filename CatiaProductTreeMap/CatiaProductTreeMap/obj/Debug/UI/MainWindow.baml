   M S B A M L   `   `   `  ����N  JCatiaProductTreeMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CatiaProductTreeMap.BLLCatiaProductTreeMap.BLL  5   	   9!clr-namespace:CatiaProductTreeMapCatiaProductTreeMap  5   	   '    !CatiaProductTreeMap.UI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5bll%clr-namespace:CatiaProductTreeMap.BLL     5   	   3local!clr-namespace:CatiaProductTreeMap     5   	   -   5          � Topmost  .  � WindowStartupLocation$ CenterScreen=�5       � Title$ CatiaTreeMap��5	   	   $	��450��6   $	��300��6+    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $) #/Windows.Theme;component/Theme.xaml?�6%   %    5      .��5      � 
������� � RowDefinitions 5   
   �� 5      6   �� 5      $��40 �6   6*   .+�5   
   �� $��3,0,0,0q�6   .��5      R� -   5        $��treeView��5      ��6'   �� *DefinitionNodes+��5      �� 5       �� ItemsSource 6/   �� *
Children+.R�5      �� $��15(�6:   $��0,3,0,3q�6H   ��6$   �� *Name+6H   5      ��5      �� 5       �� 
TargetType" Q�6   .�5      �� 	 �� Property	 �@Q�
IsExpanded
 �� Value
 . 6F   5       5"      5#      �� 5$   
   -   5        $��1��5$      $��30��6   $��70��6*   $��Center=�65   $��Right=�5%      $��0,0,10,0q�6-   .��6T   Update6\   5&      5'      