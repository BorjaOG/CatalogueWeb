<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CatalogueWEB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
        }

        .full-screen-image {
            position: relative;
            width: 100%;
            height: calc(100vh - 100px); /* Ajusta el valor según la altura de tu barra de navegación */
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 10px; /* Ajusta el valor según tus preferencias */
            margin-bottom: 10px; /* Ajusta el valor según tus preferencias */
        }

        .image-container {
            width: 100%; /* Ajusta el valor según tus preferencias */
            height: 80%; /* Ajusta el valor según tus preferencias */
            overflow: hidden;
        }

            .image-container img {
                width: 100%;
                height: 100%;
                object-fit: cover;
                 /* Cambia el valor de opacidad según tus preferencias */
            }

        .centered-content {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            text-align: center;
        }

            .centered-content h1 {
                font-size: 32px; /* Ajusta el tamaño de fuente según tus preferencias */
                color: #fff; /* Cambia el color del texto según tus preferencias */
            }

            .centered-content button {
                margin-top: 20px; /* Ajusta el margen superior del botón según tus preferencias */
                padding: 10px 20px; /* Ajusta el relleno del botón según tus preferencias */
                font-size: 16px; /* Ajusta el tamaño de fuente del botón según tus preferencias */
                background-color: #fff; /* Cambia el color de fondo del botón según tus preferencias */
                color: #000; /* Cambia el color del texto del botón según tus preferencias */
                border: none;
                border-radius: 5px; /* Ajusta el radio del borde del botón según tus preferencias */
                cursor: pointer;
            }

        @media (max-width: 767px) {
            .full-screen-image {
                height: calc(100vh - 50px); /* Ajusta el valor según la altura de tu barra de navegación móvil */
                margin-top: 5px; /* Ajusta el valor según tus preferencias */
                margin-bottom: 5px; /* Ajusta el valor según tus preferencias */
            }
        }

        .ps5-button {
            background: none;
            border: none;
            padding: 0;
            width: 100px; /* Ajusta el ancho según tus preferencias */
            height: 100px; /* Ajusta la altura según tus preferencias */
        }

            .ps5-button img {
                width: 100%;
                height: 100%;
            }
             .typing-effect {
        overflow-wrap: break-word;
        word-wrap: break-word;
        word-break: break-all;
        white-space: pre-line;
    }

    @keyframes typing {
        from {
            width: 0;
        }
        to {
            width: 100%;
        }
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: -10%; margin-bottom: -10%" class="full-screen-image">
        <div class="image-container">
            <img src="Images/room.jpg" alt="Alternate Text" />
        </div>
        <div class="centered-content">
            <h1  style="font-weight:900">Gaming Paradise</h1>
            <div class="typing-effect">
            <p id="description-text"  style="color:#fff;font-weight:500">Elevate your gaming experience with us! Discover consoles and gaming gear for the ultimate gaming adventure. Shop now and level up!</p>
           </div> <a href="Default.aspx">
                <img class="ps5-button" src="https://www.evilcontrollers.com/media/catalog/product/optimized/b/b/bb846de368454632750b8c90aef3e3db11e8ed81c3558a9ab9006dc7255a6545/ps5-creator-background-face.png" alt="Mando PS5"></a>
        </div>
    </div>

<script>
    window.addEventListener('DOMContentLoaded', function () {
        var descriptionText = document.getElementById('description-text');
        var textToType = "Elevate your gaming experience with us! Discover consoles and gaming gear for the ultimate gaming adventure. Shop now and level up!";
        var typingSpeed = 100; // Velocidad de tipeo en milisegundos

        function typeText() {
            var lines = textToType.split('\n');
            var index = 0;
            var lineIndex = 0;
            var intervalId = setInterval(function () {
                var line = lines[lineIndex];
                var lineText = line.slice(0, index);
                descriptionText.innerHTML = lineText;
                index++;
                if (index > line.length) {
                    clearInterval(intervalId);
                    if (lineIndex === lines.length - 1) {
                        descriptionText.classList.remove('typing-effect');
                    } else {
                        lineIndex++;
                        index = 0;
                        setTimeout(typeText, 1000); // Retardo entre líneas
                    }
                }
            }, typingSpeed);
        }

        function checkView() {
            if (window.innerWidth <= 767) {
                descriptionText.classList.add('typing-effect');
                typeText();
            } else {
                descriptionText.innerHTML = textToType;
                descriptionText.classList.remove('typing-effect');
            }
        }

        checkView();

        window.addEventListener('resize', checkView);
    });
</script>
</asp:Content>

