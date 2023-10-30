<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Comercio.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="dark">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="p-3 text-center text-primary-emphasis bg-primary-subtle rounded-1">
            <h4>MANTECA PANADERIAS</h4>
        </div>
        <div>
            <h3 class="p-1 text-center">Login</h3>
        </div>
        <%--Login --%>
        <div class="container">
            <div class="row">
                <div class="col-md-6 offset-md-3">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title text-center">Inicio de Sesión</h5>
                                <div class="mb-3">
                                    <label for="inputEmail" class="form-label">Usuario</label>
                                    <asp:TextBox  type="email" ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <label for="inputPassword" class="form-label">Contraseña: </label>
                                    <asp:TextBox  type="password" ID="txtContraseña" runat="server" CssClass="form-control"></asp:TextBox>                      
                                </div>
                                <div class="mb-3">                                    
                                         <label class="form-check-label" for="gridCheck1">¿Te olvidaste tu contraseña?</label>
                                </div>
                            <div class="text-center">
                                <button type="submit" class="btn btn-primary">Ingresar</button>
                            </div>
                                
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--fin de Login--%>
    </form>
</body>
</html>
