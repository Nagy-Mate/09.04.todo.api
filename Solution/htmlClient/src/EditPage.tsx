import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

function EditPage() {
  const { id } = useParams();
  const [todo, setTodo] = useState();

  useEffect(() => {
    const dataFetch = async () => {
      try {
        const url = "http://localhost:5249/list/";
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
                <label></label>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </>
  );
}

export default EditPage;
