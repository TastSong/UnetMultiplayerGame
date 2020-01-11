# UnetMultiplayerGame
## Network Manager组件

* unity中进行联网的组建，但是要在带联网的物体时添加`Network Identity`组建，用以表明此物体是要进行联网处理的。
* 为实现服务器端和客户端分别控制自己物体，要使用系统变量`isLocalPlayer`,进行判断，不过此变量需要继承`NetworkBehavior`，所以要修改脚本的继承父类。
* 像子弹此类物体需要现在服务端进行工作，然后将结果同步到客户端，此时需要将子弹的处理函数前添加`Command`属性，并且函数名前添加`Cmd`。



## OnStartLocalPlayer函数

* 这个方法只会在本地角色那里调用，当角色被创建的时候。在此项目中进行重写`override`此方法，用来修改用户控制物体的颜色。

## Slider控件

* 通过此控件进行表示血量条。
* 此物体放在要表示的物体目录下，在修改此空间相对于物体的的位置时，要将画布的`RederMode`属性改成`WorldSpace`，来调整`Slider`控件位置。







