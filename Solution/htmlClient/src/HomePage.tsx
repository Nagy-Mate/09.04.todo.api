import { useEffect, useState } from "react";
import "./Homepage.css";
import dayjs from "dayjs";

function HomePage() {
  const [todos, setTodos] = useState([]);
  const [showAll, setShowAll] = useState<boolean>(false);

  useEffect(() => {
    const dataFetch = async () => {
      try {
        const url = showAll
          ? "http://localhost:5249/list/"
          : "http://localhost:5249/listNotReady/";
        const response = await fetch(url);
        const data = await response.json();
        setTodos(data);
        console.log(todos);
      } catch (error) {
        console.error("Hiba történt az adatok lekérésekor:", error);
      }
    };
    dataFetch();
  }, [showAll]);

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
          {todos.map((todo) => (
            <tr key={todo.id}>
              <td>{todo.title}</td>
              <td>{todo.description}</td>
              <td>{dayjs(todo.Deadline).format("YYYY. MMMM D. HH:mm")}</td>
              <td>{todo.isReady ? "Kész" : "Nincs Kész"}</td>
              <td>
                <a href={`http://localhost:5173/editPage/${todo.id}`}>
                  Szerkesztés
                </a>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
export default HomePage;
