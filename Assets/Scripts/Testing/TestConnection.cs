using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class TestConnection : MonoBehaviour
{
    //mysql://root:isVcFrfRTOCNcnQQYWkAVyXuogMgSBsr@roundhouse.proxy.rlwy.net:31463/railway
    //Server=roundhouse.proxy.rlwy.net;Database=railway;User=root;Password=isVcFrfRTOCNcnQQYWkAVyXuogMgSBsr;Port=31463;

    private string connectionString;
    private MySqlConnection connection;
    [SerializeField] UsersData usersA;
    [SerializeField] TMP_Text email;
    [SerializeField] TMP_Text password;
    [SerializeField] TMP_Text emailLogin;
    [SerializeField] TMP_Text passwordLogin;
    [SerializeField] SceneData scene;
    public static Action SetScore;
    private void Start()
    {
        // Configura la cadena de conexion
        connectionString = "Server=roundhouse.proxy.rlwy.net;Database=railway;User=root;Password=isVcFrfRTOCNcnQQYWkAVyXuogMgSBsr;Port=31463;";
        ConnectToDatabase();
    }
    private void OnEnable()
    {
        DontDestroyOnLoad(this);
        SetScore += Setscore;
    }
    private void OnDisable()
    {
        SetScore -= Setscore;
    }
    private void Setscore()
    {
        if (usersA == null)
        {
            Debug.LogError("No hay usuario logeado.");
            return;
        }

        try
        {
            string query = "UPDATE LogIn SET Score = @Score WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Score", usersA.Score);
            cmd.Parameters.AddWithValue("@Id", usersA.Id);

            cmd.ExecuteNonQuery();
            Debug.Log("Score actualizado correctamente.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error al actualizar el score: " + e.Message);
        }
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
        if (IsEmailRegistered(email.text))
        {
            Debug.LogError("El correo electrónico ya está registrado.");
        }
        else
        {
            InsertData(email.text, password.text, usersA.Score);
        }
        
    }
    public bool IsEmailRegistered(string email)
    {
        bool isRegistered = false;

        try
        {
            string query = "SELECT COUNT(*) FROM LogIn WHERE Email = @email";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@email", email);

            isRegistered = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        catch (Exception e)
        {
            Debug.LogError("Error al verificar si el correo está registrado: " + e.Message);
        }

        return isRegistered;
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