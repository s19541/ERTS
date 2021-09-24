import React from "react";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { TournamentShortDto } from "../../../services/GeneratedClient";

function LolTournamentListTableRow(props: {
	tournament: TournamentShortDto;
	leagueId: number;
}) {
	const tournament = props.tournament;
	const leagueId = props.leagueId;

	const startTime = tournament.startTime?.format("HH:mm DD-MM-YYYY");
	const endTime = tournament.endTime?.format("HH:mm DD-MM-YYYY");

	return (
		<tr key={tournament.id} data-href="/">
			<td>
				<a href={`${leagueId}/${tournament.id}/scoreBoard`}>
					{" "}
					{tournament.name}
				</a>
			</td>
			<td>{startTime}</td>
			<td>{endTime}</td>
		</tr>
	);
}
export default LolTournamentListTableRow;
