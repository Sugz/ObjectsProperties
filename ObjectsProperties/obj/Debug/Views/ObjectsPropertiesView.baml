   M S B A M L   `   `   `  ����T  PObjectsProperties, Version=0.12.5891.16223, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ObjectsProperties.ViewModelsObjectsProperties.ViewModels  5      A%clr-namespace:ObjectsProperties.ViewsObjectsProperties.Views  5      3    -ObjectsProperties.Views.ObjectsPropertiesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9vm*clr-namespace:ObjectsProperties.ViewModels     5      7local%clr-namespace:ObjectsProperties.Views     5      $	��300��5	         MaxToolbarStyle#���   5
        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $! Styles/MaxToolbarStyle.xaml?�6%   %    5       � DataContext 5      6   0ObjectsProperties.ViewModels.ObjectsPropertiesVM  5   
   .��5      �   
Background#���  6   .+�5   
   �� $��Name :��6   $
��Wrap=�5      $��11(�5      $
��Left=�5      $	��Top=�5      $��5,10,0,0q�5       ���	#FFE1E1E15!      �� 5#   
   -   5         ��Name$ NameTxt��5#       �� TextWrapping$
 Wrap=�5%      $��11(�5&      $��16��5'      $	��Top=�5(      $��	45,10,5,0q�5)      $��1,-2,1,0q�5*      ���	#FF505050���	#FF6E6E6E���	#FFE1E1E1��5$      �� *	NameTxt+ �� UpdateSourceTrigger$ PropertyChanged=� �� 
IsReadOnly 5.      �� *NameTxtReadOnly+ �� Mode$ OneWay=��� 50   
   $��
Material :��6   $
��Wrap=�51      $��11(�52      $
��Left=�53      $	��Top=�54      $��5,30,0,0q�55      ���	#FFE1E1E156      �� 58   
   -   5        $ MaterialTxt��58      $
 Wrap=�5:      $��11(�5;      $��16��5<      $	��Top=�5=      $��	55,30,5,0q�5>      $��1,-2,1,0q�5?      ���	#FF505050���	#FF6E6E6E���	#FFE1E1E1 . ��59      �� *MaterialTxt+5C      �� 5E   
   -   5        	 ��Name$	 SelectRootsBtn��5E      $��Select Roots��6)   

 � Tag$
 roots��6@   $
��Left=�6L   $��5,80,0,0q�6g   $	��Top=�6y   $	��108��6�   ��6�   �� *SelectByProperties+��6�   ��  �� ElementName$ SelectRootsBtn���� 5F   
   -   5        $	 testBtn��5F      $
��Test��6"   $

 test��61   $
��Left=�6=   $��
131,80,0,0q�6X   $	��Top=�6l   $	��108��6�   ��6�   �� *SelectByProperties+��6�   �� $ testBtn���� 5H   
   -   5        $ CheckBtnTxt��5H      $
 Wrap=�5J      $��11(�5K      $��16��5L      $	��Top=�5M      $��28,117,32,0q�5N      $��1,-2,1,0q�5O      ���	#FF505050���	#FF6E6E6E���	#FFE1E1E1 . ��5I      �� *CheckBtnTxt+5S      2   ,ObjectsProperties.Views.IsolateSelectionView  5V   
   $
��Left=�6%   $��
28,188,0,0q�6@   $	��Top=�6T   5Y      5Z      