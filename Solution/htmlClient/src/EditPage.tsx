import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

function EditPage() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [todo, setTodo] = useState({});

  const saveOnBtnClick = async () => {
    try {
      const editedTodo = {
        id: todo.id,
        title: todo.title && todo.title.trim() !== "" ? todo.title : "",
        description:
          todo.description && todo.description.trim() !== ""
            ? todo.description
            : "",
        deadLine: todo.deadLine ? new Date(todo.deadLine).toISOString() : null,
      };

      const response = await fetch("http://localhost:5249/update/", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(editedTodo),
      });

      if (!response.ok) {
        throw new Error("Hiba a módosítás során");
      }

      alert("Sikeres mentés!");
      navigate("/homepage");
    } catch (error) {
      console.error("Hiba történt a mentés során:", error);
    }
  };

  useEffect(() => {
    const dataFetch = async () => {
      try {
        const url = `http://localhost:5249/list/${id}`;
        const response = await fetch(url);
        const data = await response.json();
        setTodo(data);
      } catch (error) {
        console.error("Hiba történt az adatok lekérésekor:", error);
      }
    };

    dataFetch();
  }, []);

  return (
    <>
      <h1>Todo Update</h1>

      <div>
        <table>
          <tbody>
            <tr>
              <td>
                <label>Title</label>
              </td>
              <td>
                <input
                  type="text"
                  value={todo.title || ""}
                  onChange={(e) => setTodo({ ...todo, title: e.target.value })}
                />
              </td>
            </tr>
            <tr>
              <td>
                <label>Description</label>
              </td>
              <td>
                <input
                  type="text"
                  value={todo.description || ""}
                  onChange={(e) =>
                    setTodo({ ...todo, description: e.target.value })
                  }
                />
              </td>
            </tr>
            <tr>
              <td>
                <label>Deadline</label>
              </td>
              <td>
                <input
                  type="date"
                  value={todo?.deadLine ? todo.deadLine.split("T")[0] : ""}
                  onChange={(e) =>
                    setTodo({ ...todo, deadLine: e.target.value })
                  }
                />
              </td>
            </tr>
          </tbody>
        </table>
        <button type="button" onClick={saveOnBtnClick}>
          Mentés
        </button>
      </div>
    </>
  );
}

export default EditPage;
