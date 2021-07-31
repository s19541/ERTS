import React from "react";
import { Link } from "react-router-dom";
import { TournamentShortDto } from "../../../services/GeneratedClient";

function LolTournamentListTableRow(props: { tournament: TournamentShortDto }) {
	const tournament = props.tournament;

	const startTime = tournament.startTime.format("HH:mm DD-MM-YYYY");
	const endTime = tournament.endTime.format("HH:mm DD-MM-YYYY");

	return (
		<tr key={tournament.id}>
			<td>{tournament.name}</td>
			<td>{startTime}</td>
			<td>{endTime}</td>
		</tr>
	);
}
export default LolTournamentListTableRow;
