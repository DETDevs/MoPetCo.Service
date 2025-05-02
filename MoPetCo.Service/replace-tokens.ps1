# rutas de los archivos
$appsettingsPath = "appsettings.json"
$envFilePath = "env.values.json"

# leer y parsear los archivos
$envValues = Get-Content $envFilePath -Raw | ConvertFrom-Json
$appsettingsContent = Get-Content $appsettingsPath -Raw

# reemplazmos las variables tipo ${VAR_NAME}
foreach ($property in $envValues.PSObject.Properties) {
    $token = '${' + $property.Name + '}'
    $value = $property.Value -replace '\\', '\\\\'  # Escapar backslashes
    $escapedToken = [regex]::Escape($token)
    $appsettingsContent = $appsettingsContent -replace $escapedToken, $value
}

# Guardar el nuevo archivo appsettings.json con valores reales
Set-Content -Path $appsettingsPath -Value $appsettingsContent
