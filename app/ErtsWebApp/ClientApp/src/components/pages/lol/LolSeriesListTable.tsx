import React from "react";
import { Table } from "react-bootstrap";
import { SeriesShortDto } from "../../../services/GeneratedClient";
import LolSeriesListTableRow from "./LolSeriesListTableRow";

function LolSeriesTable(props: { seriesList: SeriesShortDto[] | null }) {
	const seriesList = props.seriesList;

	return (
		<Table striped bordered hover variant="dark">
			<thead>
				<tr>
					<th>Start Time</th>
					<th style={{ textAlign: "right" }}>Blue Team</th>
					<th style={{ width: "5vh", textAlign: "center" }}>Result</th>
					<th>Red Team</th>
					<th style={{ width: "5vh", textAlign: "center" }}>Mode</th>
				</tr>
			</thead>
			<tbody>
				{seriesList?.map((series, i) => (
					<LolSeriesListTableRow series={series} />
				))}
			</tbody>
		</Table>
	);
}

export default LolSeriesTable;
