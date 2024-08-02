using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TestConnection : MonoBehaviour
{
    //mysql://root:SCjGXuTVHPyxmwEPUdVDlTTBAHKVeUwL@roundhouse.proxy.rlwy.net:55323/railway
    //Server=roundhouse.proxy.rlwy.net;Database=railway;User=root;Password=SCjGXuTVHPyxmwEPUdVDlTTBAHKVeUwL;Port=55323;

    private string connectionString;
    private MySqlConnection connection;
    [SerializeField] UsersData usersA;
    [SerializeField] TMP_Text email;
    [SerializeField] TMP_Text password;
    [SerializeField] TMP_Text emailLogin;
    [SerializeField] TMP_Text passwordLogin;
    [SerializeField] SceneData scene;
    private void Start()
    {
        // Configura la cadena de conexion
        connectionString = "Server=roundhouse.proxy.rlwy.net;Database=railway;User=root;Password=SCjGXuTVHPyxmwEPUdVDlTTBAHKVeUwL;Port=55323;";
        ConnectToDatabase();
    }

    private void ConnectToDatabase()
    {
        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Debug.Log("Conexion exitosa a la base de datos.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error al conectar a la base de datos: " + e.Message);
        }
    }
    public void UploadData()
    {
        InsertData(email.text, password.text, usersA.Score);
    }
    public void DownloadData()
    {
        string userEmail = emailLogin.text;
        string userPassword = passwordLogin.text;
        usersA = GetUserByEmailAndPassword(userEmail, userPassword);

        if (usersA != null)
        {
            Debug.Log($"Login exitoso. ID: {usersA.Id}, Email: {usersA.Email}, Score: {usersA.Score}");
            // Puedes cargar la escena aquí si el login es exitoso
            GameController.Register?.Invoke(true);
            if (scene.OpcionMultiple)
            {
                SceneManager.LoadScene("OpcionMultiple");
            }
            else if (scene.OrdenadoPorBloques)
            {
                SceneManager.LoadScene("OrdenadoPorBloques");
            }
            else if (scene.UniendoPorLineas)
            {
                SceneManager.LoadScene("UniendoPorLineas");
            }
        }
        else
        {
            Debug.LogError("Login fallido. Email o contraseña incorrectos.");
        }
    }
    public void InsertData(string email, string password, int score)
    {
        try
        {
            string query = "INSERT INTO LogIn (Email, Password, Score) VALUES (@email, @password, @score)";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@score", score);

            cmd.ExecuteNonQuery();
            Debug.Log("Datos insertados correctamente.");
            
        }
        catch (Exception e)
        {
            Debug.LogError("Error al insertar datos: " + e.Message);
        }
    }
    public UsersData GetUserByEmailAndPassword(string email, string password)
    {
        //usersA = null;

        try
        {
            string query = "SELECT * FROM LogIn WHERE Email = @email AND Password = @password";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.Read())
            {
                //usersA = new UsersData();
                usersA.Id = dataReader.GetInt32("id");
                usersA.Email = dataReader.GetString("Email");
                usersA.Password = dataReader.GetString("Password");
                usersA.Score = dataReader.GetInt32("Score");
            }

            dataReader.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("Error al recibir datos: " + e.Message);
        }

        return usersA;
    }
    private void OnDestroy()
    {
        if (connection != null)
        {
            connection.Close();
        }
    }
}