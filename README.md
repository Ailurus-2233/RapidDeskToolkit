# RapidDeskToolkit

个人学习 Avalonia 框架所创建的代码仓库。

一个基于 Avalonia 框架的桌面端应用程序快速开发工具，提供了一些基础的桌面应用程序开发模块和工具，可以帮助开发者快速的构建一个桌面应用程序。

## 项目结构

### RapidDeskToolkit.Common

定义了在开发程序的过程中需要的一些基础的接口和工具，包括：

- 应用控制器 ApplicationController
- 启动引导 Bootstrapper
- IoC 容器 Container
- 模块加载 ModuleLoader
- 资源加载器 ResourceLoader
- 事件聚合器 EventAggregator
- Assembly 加载器 AssemblyHandler

### RapidDeskToolkit.Models

定义了一些基础的数据类型，包括：

- Event 事件，定义了工具内事件的基本结构和工具加载过程中的一些事件
- Exception 异常，定义了工具内异常的基本结构和工具加载过程中的一些异常

### RapidDeskToolkit.Modules

定义了模块的基本结构，以及模块加载器 ModuleLoader，模块的基本结构包括：

- Initialize 方法，用于初始化模块
- OnLoadModule 方法，用于在模块加载时执行的操作
- OnUnloadModule 方法，用于在模块卸载时执行的操作
- ModuleName 属性，模块的名称，用于标识模块，不可重复
- ModuleControl 属性，模块对应的控件，用于显示模块的内容

### RapidDeskToolkit.Services

定义了服务的基本结构，以及服务加载器 ServiceLoader，服务的基本结构包括：

- Initialize 方法，用于初始化服务
- OnStartService 方法，用于在打开服务时执行的操作
- OnStopService 方法，用于在关闭服务时执行的操作
- ServiceName 属性，服务的名称，用于标识服务，不可重复

## 项目预览

## 如何使用

## 开发状态

本项目目前处于开发阶段，尚未发布第一个稳定版本。如果您对本项目感兴趣，欢迎您参与项目的开发和测试，或者提出宝贵的意见和建议。

## 开源许可证

本项目使用 GPL 3.0 许可证进行授权，请查看 [这里](https://www.gnu.org/licenses/gpl-3.0.html) 获取 GPL 3.0 许可证的详细信息。

> 使用须知
>
> 根据 GPL 3.0 许可证的要求，您在使用、修改或分发本项目时必须遵守许可证的规定。请确保您已阅读并理解许可证的条款和条件，并遵守以下要求：
>
> - 在**任何衍生创作中都必须保留 GPL 3.0 许可证**，并提供源代码和相应的授权文件。
> - 如果您对本项目进行了修改或衍生创作，并进行了分发，您需要在相应的授权文件中明确说明您对原始软件所做的修改，并将修改后的软件以
    GPL 3.0 许可证进行分发。
> - 如果您使用本项目创建了其他软件，并且不以 GPL 3.0 许可证进行分发，您不能要求其他人仅仅因为使用您的软件而受到 GPL 3.0
    许可证的限制。
>
>
如果您对项目或许可证有任何疑问或需要更多信息，请联系作者（邮箱：[Ailurus2233@outlook.com](mailto:ailusu2233@outlook.com)）。
