﻿using GastroByte.Dtos;
using GastroByte.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastroByte.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            UsuarioDto user = new UsuarioDto
            {
                Response = 0, // Inicializa Response en 0 o algún valor por defecto
                Message = string.Empty // Inicializa Message como una cadena vacía
            };
            return View(user);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioDto newUser)
        {
            if (newUser == null)
            {
                newUser = new UsuarioDto();
                newUser.Message = "El modelo de usuario no se envió correctamente.";
                return View(newUser);
            }

            try
            {
                UsuarioService userService = new UsuarioService();
                UsuarioDto userResponse = userService.CreateUser(newUser);

                if (userResponse.Response == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Asegúrate de que `Message` tenga un valor
                    if (string.IsNullOrEmpty(userResponse.Message))
                    {
                        userResponse.Message = "Error al crear el usuario. Por favor, inténtalo nuevamente.";
                    }
                    return View(userResponse);
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, devuelves el modelo con un mensaje de error
                newUser.Message = "Ocurrió un error inesperado: " + ex.Message; // Muestra el mensaje de la excepción
                newUser.Response = 0;
                return View(newUser);
            }
        }


        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}