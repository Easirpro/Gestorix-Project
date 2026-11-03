# Gestroix-Project
Practicas Profesionalizares

Sistema de gestión para kioscos en C# (Windows Forms) con SQL Server, organizado en capas:
CapaVista, CapaLogica, CapaDatos y CapaEntidades (`KiocoSistemaFinal/SistemaFinalKiosco`).

Módulos: ventas y cobros, artículos (importación/exportación Excel), categorías y marcas, promociones,
compras y recepción, cuenta corriente y pagos a proveedores, devoluciones, caja (apertura, cierre,
movimientos e historial), balance, empleados, roles y permisos, login con preguntas de seguridad,
bitácora, backup y dígito verificador (DVH).

## Puesta en marcha
1. Instalar **SQL Server 2025 Express** (o más nuevo) con la instancia `SQLEXPRESS`: la cadena de conexión de
   `CapaDatos/Conexion.cs` apunta a `.\SQLEXPRESS` (la base local de cada PC) con autenticación de Windows.
2. Restaurar la base de referencia: descomprimir `KiocoSistemaFinal/BaseDatos/Gestorix_referencia_0.0.1.0.zip`
   (trae el `.bak` y su firma `.hash`) y restaurarla en SSMS con el nombre `Gestorix`
   (Bases de datos > Restaurar base de datos > Dispositivo). El backup es de SQL Server 2025: no se puede
   restaurar en versiones anteriores. Ya tiene aplicados todos los `Migracion_*.sql`, el DVH recalculado
   y los errores técnicos revisados; `KioscoFinal.sql` es el script viejo y no alcanza para crear la base.
3. Abrir `SistemaFinalKiosco.sln` en Visual Studio 2022 y compilar.

## Instalación en una PC
1. Instalar **SQL Server 2025 Express** (o más nuevo) con la instancia `SQLEXPRESS`, con el usuario de Windows
   que va a usar Gestorix (queda como administrador del servidor). El instalador de Gestorix no sigue si no lo encuentra.
2. Ejecutar `Instalar_Gestorix_0.0.1.0.exe`: instala el programa en `Archivos de programa\Gestorix`, crea los accesos
   directos, deja la base de referencia en `C:\Gestorix\BaseInicial` y le da permiso a SQL Server sobre `C:\Gestorix`.
3. Abrir Gestorix: la primera vez, si no existe la base `Gestorix`, la crea sola desde la base de referencia.

Para generar el instalador: instalar [Inno Setup 6](https://jrsoftware.org/isdl.php) y ejecutar en PowerShell
`KiocoSistemaFinal\Instalador\GenerarInstalador.ps1`. Publica el programa (incluye .NET, la PC no necesita tenerlo)
y deja el instalador en `KiocoSistemaFinal\Instalador\salida`.

## Historial de versiones

0.0.0.1- 9/9 se subió el proyecto a GitHub

0.0.0.2- 9/9 se Mejoro la pantalla principal al maximizar

0.0.0.3- 9/9 se creo el Archivo .gitignore

0.0.0.4- 10/09 Se centraron los formularios y dise;o de varios formularios [Ema]

0.0.0.5- 10/09 Mejoras en la Pantalla Principal (DataGridView) y TableLayoutPanel- Marce-

0.0.0.6- 17/9 Se Mergeo GestorVentas a Main sin conflictos -Marce-

0.0.0.7- 18/9 Finaliza registro de ventas con pagos, stock y movimientos -Tobias-

0.0.0.8- 21/9 Se Agrego Permisos y roles en Empleados Administradores   -Cristian-

0.0.0.9- 21/9 Se Elimino carpeta Temporales de Visual  .vs/ del Repositorio y se Actualizo el .gitignore para que no vuelvan a subirlo -Marce-

0.0.0.10- 21/9 Se corrigio Conflictos en Merge Main-EmpleadosPermisos en ClsConexion - Marce-

0.0.0.11- 23/9 Cambios en usuarios y empleados -Cristian-

0.0.0.12- 27/9 Exportación de artículos y mejoras en la importación -Cristian-

0.0.0.13- 4/10 Migración a procedimientos almacenados y carga rápida de precios -Cristian-

0.0.0.14- 12/10 Integración de promociones y gestión de productos -Cristian-

0.0.0.15- 18/10 Módulo de gestión de backup y mejoras en artículos y promociones -Marce-

0.0.0.16- 19/10 Bitácora del sistema -Cristian-

0.0.0.17- 20/10 Dígito verificador -Marce- y traducción de menú -Cristian-

0.0.0.18- 25/10 Actualización de compras, ventas, cobros y bitácora -Cristian-

0.0.0.19- 26/10 DVH en usuarios -Marce-

0.0.0.20- 27/10 Recepción de compras y mejoras en compras y promociones -Cristian-

0.0.0.21- 28/10 DVH en ventas y hash en la base de datos -Marce-

0.0.0.22- 29/10 Caja (apertura, cierre, movimientos e historial), pagos a proveedores y balance -Tobias-

0.0.0.23- 29/10 Devoluciones y registro de promociones aplicadas en ventas -Tobias-

0.0.0.24- 29/10 Separación de capas: la vista deja de acceder a datos y se unifican ventas y productos -Tobias-

0.0.0.25- 29/10 Login con bloqueo por intentos fallidos y respuestas de seguridad con hash -Cristian-

0.0.0.26- 29/10 Corrección del alta de usuarios y del DVH al cambiar contraseña -Marce-

0.0.0.27- 29/10 Se quitó CapaVista.csproj.user del repositorio y se limpió código sin uso en usuarios -Marce-

0.0.0.28- 29/10 Cadena de conexión apuntando al servidor SQL compartido por Radmin VPN -Tobias-

0.0.0.29- 29/10 Categorías y marcas unificadas en un solo formulario, formularios ajustables y mejoras en compras, devoluciones y promociones; se quitaron la búsqueda de marca/rubro y la carga rápida de precios -Cristian-

0.0.0.30- 29/10 Login: se quitó el bloqueo por intentos fallidos y se oculta el detalle técnico de los errores -Tobias-

0.0.0.31- 30/10 Backup con base de datos remota (se genera en el servidor y se descarga a la PC que lo pide) -Marce-

0.0.0.32- 30/10 Backup compatible con el servidor SQL compartido; alertas, informes de ventas, listados y mejoras en compras y recepción -Cristian-

0.0.0.33- 30/10 Permisos por rol según el Excel; empleados con rol en combo, protección de administradores y validación de CUIL; primer ingreso y recuperación obligatorios -Cristian-

0.0.0.34- 31/10 Diseño, búsquedas y correcciones en empleados, proveedores, compras, ventas y alertas; comprobante opcional en compras y stock al anular ventas; devoluciones y ayudas en todos los formularios -Cristian-

0.0.0.35- 31/10 Idioma inglés/español en todo el sistema -Cristian-

0.0.0.36- 2/11 Artículos: solo nombre, marca, unidad de venta y rubro obligatorios; ventas no deja vender artículos sin precio; DVH de artículos con formato fijo de precio -Marce-

0.0.0.37- 2/11 Artículos con varios proveedores -Marce-

0.0.0.38- 2/11 Se vuelve a la base local (.\SQLEXPRESS en cada PC); backup y restauración en el disco local con barras de progreso -Marce-

0.0.0.39- 2/11 Verificación de integridad con DVH (productos, usuarios y ventas) al iniciar sesión y desde Administración; formatos fijos de precio, total y fecha en el DVH y DVH recalculado al cambiar precios o importar artículos -Marce-

0.0.0.40- 2/11 Base de datos de referencia (.bak verificado) en KiocoSistemaFinal/BaseDatos para instalar el sistema; errores técnicos viejos marcados como resueltos; se quitaron de Conexion.cs las cadenas de conexión viejas -Marce-

0.0.1.0- 2/11 Primera versión instalable: instalador con Inno Setup (programa autocontenido, base de referencia y permisos para SQL Server); el programa crea la base sola la primera vez y avisa si no encuentra SQL Server -Marce-

0.0.1.1- 3/11 Guía de instalación para el usuario (requisitos, pasos y solución de problemas) en KiocoSistemaFinal/Instalador -Marce-

0.0.1.2- 3/11 Importes en pesos argentinos (ARS) y en dólares (USD) con el sistema en inglés (también en la vista previa de Promociones); Registrar/Modificar artículo, Categorías y marcas, Importar y Exportar artículos sin botón de maximizar -Marce-

0.0.1.3- 3/11 Proveedores: la grilla muestra todos los proveedores y se actualiza al cargar uno nuevo; dirección "Sin número"; e-mail con dominio propio; varias sucursales por proveedor (al cargarlo o con "Nueva sucursal") y Modificar edita la sucursal elegida -Marce-
