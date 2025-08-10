import React, { useState, useEffect } from "react";
import { getCampaigns, updateStatus } from "../api";

export default function CampaignTable() {
  const [campaigns, setCampaigns] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    getCampaigns().then(setCampaigns);
  }, []);

  const handleChangeStatus = async (id, newStatus) => {
    const prevCampaigns = [...campaigns];
    setCampaigns(campaigns.map(c => c.id === id ? { ...c, status: newStatus } : c));

    try {
      await updateStatus(id, newStatus);
    } catch (err) {
      setError(err.message);
      setCampaigns(prevCampaigns);
    }
  };

  return (
    <div>
      {error && <div style={{color: "red"}}>{error}</div>}
      <table border="1">
        <thead>
          <tr>
            <th>ID</th><th>Name</th><th>Status</th><th>Budget</th><th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {campaigns.map(c => (
            <tr key={c.id}>
              <td>{c.id}</td>
              <td>{c.name}</td>
              <td>{c.status}</td>
              <td>{c.budget}</td>
              <td>
                <select value={c.status} onChange={e => handleChangeStatus(c.id, e.target.value)}>
                  <option>Active</option>
                  <option>Paused</option>
                  <option>Archived</option>
                </select>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
