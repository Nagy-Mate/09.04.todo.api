import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./Homepage.css";
import dayjs from "dayjs";

function HomePage() {
  const [todos, setTodos] = useState([]);
  const [showAll, setShowAll] = useState<boolean>(false);

  useEffect(() => {
    dataFetch();
  }, [showAll]);

  const dataFetch = async () => {
    try {
      const url = showAll
        ? "http://localhost:5249/list/"
        : "http://localhost:5249/listNotReady/";
      const response = await fetch(url);
      const data = await response.json();
      setTodos(data);
    } catch (error) {
      console.error("Hiba történt az adatok lekérésekor:", error);
    }
  };

  const deleteTodo = async (id) => {
    try {
      const response = await fetch(`http://localhost:5249/delete/${id}`, {
        method: "DELETE",
      });

      if (response.ok) {
        console.log("Sikeresen törölve");
        dataFetch();
      } else {
        console.error("Törlés sikertelen");
      }
    } catch (error) {
      console.error("Hiba történt a törlés közben:", error);
    }
  };

  return (
    <>
      <h1>TODOS</h1>
      <label>
        <input
          type="checkbox"
          checked={showAll}
          onChange={(e) => {
            setShowAll(e.target.checked);
          }}
        />
        Összes teendő mutatása
      </label>
      <table>
        <tbody>
          <tr>
            <th>Title</th>
            <th>Description</th>
            <th>Deadline</th>
            <th>Ready</th>
          </tr>
          {todos.map((todo) => {
            const isOverdue =
              dayjs(todo.deadLine).isBefore(dayjs().startOf("day")) &&
              !todo.isReady;
            return (
              <tr
                key={todo.id}
                style={isOverdue ? { backgroundColor: "lightpink" } : {}}
              >
                <td>{todo.title}</td>
                <td>{todo.description}</td>
                <td>{dayjs(todo.deadLine).format("YYYY. MMMM D. HH:mm")}</td>
                <td>{todo.isReady ? "Kész" : "Nincs Kész"}</td>
                <td>
                  <Link to={`/editPage/${todo.id}`}>Szerkesztés</Link>
                </td>
                <td>
                  <button onClick={() => deleteTodo(todo.id)}>Törlés</button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </>
  );
}
export default HomePage;
