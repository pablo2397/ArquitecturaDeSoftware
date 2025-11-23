export interface usuarios{
    IdUsuario: number,
    Usuario: string,
    Correo: string,
    Clave: string,
    Rol: string,
    Estado: boolean
}

export interface LoginResponse{
    message: string
}