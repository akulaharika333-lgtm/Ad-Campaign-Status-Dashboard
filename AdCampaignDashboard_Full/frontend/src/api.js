const API_BASE = "https://localhost:50408/api/campaigns";
const API_KEY = "Ad-Api-Key-123";

export async function getCampaigns() {
  const res = await fetch(API_BASE);
  return res.json();
}

export async function updateStatus(id, newStatus) {
  const res = await fetch(`${API_BASE}/${id}/status`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "X-API-KEY": API_KEY
    },
    body: JSON.stringify({ newStatus })
  });
  if (!res.ok) throw new Error(await res.text());
  return res.json();
}
