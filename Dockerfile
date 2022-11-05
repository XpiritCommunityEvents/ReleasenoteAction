# Set the base image as the .NET 6.0 SDK (this includes the runtime)
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

# Copy everything and publish the release (publish implicitly restores and builds)
WORKDIR /app
COPY . ./
RUN dotnet publish ./GenerateReleaseNotes/GenerateReleaseNotes.csproj -c Release -o out --no-self-contained

# Label the container
LABEL maintainer="Marcel de Vries <vriesmarcel@hotmail.com>"
LABEL repository="https://github.com/XpiritCommunityEvents/GenerateReleaseNotes"
LABEL homepage="https://github.com/XpiritCommunityEvents/GenerateReleaseNotes"

# Label as GitHub action
LABEL com.github.actions.name="Generate Release Notes (used in HOL)"
# Limit to 160 characters
LABEL com.github.actions.description="This GitHub Action creates release notes and has some hidden gems used in the workshop"
# See branding:
# https://docs.github.com/actions/creating-actions/metadata-syntax-for-github-actions#branding
LABEL com.github.actions.icon="file-text"
LABEL com.github.actions.color="orange"

# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "/GenerateReleaseNotes.dll" ]