   M S B A M L   `   `   `  ????D  @ECommerce, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ECommerce.Domain.ViewsECommerce.Domain.Views  5      '    !ECommerce.Domain.Views.HomePageUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ECommerce.Domain.Views     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6A   .??5	      ? 
???????.+?5
   
   ?? .+?5      ?? $??0,0,0,5q?6   
??? ???._?5      ?? $	??800??6     ?? Orientation$  
Horizontal=?6)   .+?5      ?? 
??? ??? ?? Padding$ 10q?65   $??Center=?6B   $??30(?6_   $??Comic Sans MS)?6m   E-Commerce App6?   ?? 5      
??? ???$??20q?5      $??Cascadia Code SemiBold)?5      
???????$??
ExtraBlack"?5      $??0q?5      $??25(?5      ??5      ?? *ToLowerCommand+??5      ?? *
FilterText+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5   %   ?? 5      $??10,0,0,0q?5      $??Admin??5      
??? ???$??20q?5      
???????$??Cascadia Code SemiBold)?5      $??
ExtraBlack"?5      $??0q?5       $??25(?5"      ??5!      ?? *AdminCommand+5"   %   ?? 5#      $??10,0,0,0q?5$      $??Orders??5%      
??? ???$??20q?5'      
???????$??25(?5)      $??Cascadia Code SemiBold)?5*      $??
ExtraBlack"?5+      $??0q?5,      ??5-      ?? *OrdersCommand+69   5.      5/      ?? 51      $??10q?53      
???????
??? ???$??5,0,5,5q?6F   ??52      ?? *AllProducts+ ?? SelectedItem 65   ?? *SelectedProduct+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 54      +  %Microsoft.Xaml.Behaviors.EventTrigger  55         	EventName$ SelectionChanged??6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 56      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   ?? *SelectProductCommand+6\   57      	 ?? View	 59      ?? 5:      .P?5;      ?? $
??Name??6)   
 ?? Width$	
 200??67    ?? CellTemplate 5<      ?? 5=   "   .R?5>   &   ?? $??Cascadia Code SemiBold)?60   $??18(?6T   $??Center=?6b   $	 5,2q?6   ??6?   ?? *Name+6?   5?   #   5A      ?? 5B      $??Price??6)   $	
 200??68    5C      ?? 5D   "   .R?5E   &   ?? $  
Horizontal=?61   .+?5F   *   ??  ?? TextAlignment$ Center=?64   $??Cascadia Code SemiLight)?6K   $??18(?6p   ??6~   ?? *Price+6?   ?? 5G   *   $??Cascadia Code SemiLight)?64   $??18(?6Y   $??$??6g   6s   5H   '   5I   #   5K      ?? 5L      $??Discount??6)   $	
 200??6;    5M      ?? 5N   "   .R?5O   &   ?? $  
Horizontal=?61   .+?5P   *   ?? $??Cascadia Code SemiBold)?64   $??18(?6X   ??6f   ?? *
Discount+6?   ?? 5Q   *   $??Cascadia Code SemiBold)?64   $??18(?6X   $??%??6f   6r   5R   '   5S   #   5U      ?? 5V      $??Quantity??6)   $	
 190??6;    5W      ?? 5X   "   .R?5Y   &   ?? $  
Horizontal=?61   .+?5Z   *   ?? $??18(?64   ??6B   ?? *
Quantity+6_   5[   '   5\   #   5^      5_      5a      5b      5c      5d      