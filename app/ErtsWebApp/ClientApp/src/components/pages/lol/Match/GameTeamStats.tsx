import { Container, Row, Col } from "react-bootstrap";
import { LolGameTeamStatsDto } from "../../../../services/GeneratedClient";

function GameTeamStats(props: { teamStats: LolGameTeamStatsDto | undefined }) {
	const teamStats = props.teamStats;

	return (
		<Container>
			Gold: {teamStats?.goldEarned}
			Dragons:
			{[...Array(teamStats?.oceanDrakeKilled)].map((x, i) => (
				<img
					src="/images/lol/ocean-drake-icon.png"
					width={29}
					height={29}
					alt="oceanDrake"
				/>
			))}
			{[...Array(teamStats?.infernalDrakeKilled)].map((x, i) => (
				<img
					src="/images/lol/infernal-drake-icon.png"
					width={29}
					height={29}
					alt="infernalDrake"
				/>
			))}
			{[...Array(teamStats?.mountainDrakeKilled)].map((x, i) => (
				<img
					src="/images/lol/mountain-drake-icon.png"
					width={29}
					height={29}
					alt="mountainDrake"
				/>
			))}
			{[...Array(teamStats?.cloudDrakeKilled)].map((x, i) => (
				<img
					src="/images/lol/cloud-drake-icon.png"
					width={29}
					height={29}
					alt="cloudDrake"
				/>
			))}
			<img
				src="/images/lol/elder-drake-icon.png"
				width={29}
				height={29}
				alt="elderDrake"
			/>
			:{teamStats?.elderDrakeKilled}
			<img
				src="/images/lol/herald-icon.png"
				width={29}
				height={29}
				alt="herald"
			/>
			:{teamStats?.heraldKilled}
			<img
				src="/images/lol/baron-icon.png"
				width={29}
				height={29}
				alt="baron"
			/>
			:{teamStats?.baronKilled}
			<img
				src="/images/lol/tower-icon.png"
				width={29}
				height={29}
				alt="tower"
			/>
			:{teamStats?.turretDestroyed}
			<img
				src="/images/lol/inhibitor-icon.png"
				width={29}
				height={29}
				alt="inhibitor"
			/>
			//TODO zmienic na inhibitor :{teamStats?.turretDestroyed}
			Bans:
			<img src={teamStats?.ban1ImageUrl} className="" width={29} height={29} />
			<img src={teamStats?.ban2ImageUrl} className="" width={29} height={29} />
			<img src={teamStats?.ban3ImageUrl} className="" width={29} height={29} />
			<img src={teamStats?.ban4ImageUrl} className="" width={29} height={29} />
			<img src={teamStats?.ban5ImageUrl} className="" width={29} height={29} />
		</Container>
	);
}

export default GameTeamStats;
